using Butterfly.Service.Expenses.DataModel;
using Butterfly.Service.Expenses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.Service.Expenses
{
    public class ExpensesDataService
    {
        #region Categories
        public static Response DeleteCategory(DeleteCategoryRequest request)
        {
            Response response = new Response();
            response.SetFAILED();
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    Category category = context.Category.FirstOrDefault(p => p.Name.Equals(request.Name, StringComparison.CurrentCultureIgnoreCase));
                    if (category != null)
                    {
                        context.Category.Remove(category);
                        context.SaveChanges();
                        response.SetSUCCESS();
                    }
                    else
                    {
                        response.ResultMessage = String.Format("Category {0} not found", request.Name);
                    }
                }
            }
            return response;
        }
        public static Response DeleteExpenseCategory(DeleteExpenseCategoryRequest request)
        {
            Response response = new Response();
            response.SetFAILED();
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    ExpenseCategory category = context.ExpenseCategory.FirstOrDefault(p => p.Id == request.Id);
                    if (category != null)
                    {
                        context.ExpenseCategory.Remove(category);
                        context.SaveChanges();
                        response.SetSUCCESS();
                    }
                    else
                    {
                        response.ResultMessage = String.Format("Category {0} not found", request.Id);
                    }
                }
            }
            return response;
        }
        public static List<ExpenseCategory> GetExpenseCategories()
        {
            using (ExpensesEntities context = new ExpensesEntities())
            {
                IQueryable<ExpenseCategory> items =
                    from item in context.ExpenseCategory
                    orderby item.Date descending
                    select item;
                return items.ToList();    
            }
        }
        public static List<Category> GetCategories(string pattern)
        {
            using (ExpensesEntities context = new ExpensesEntities())
            {
                IQueryable<Category> items =
                        from item in context.Category                       
                        select item;

                return items.ToList();
            }
            
        }
        public static Category FindOrCreateCategory(string category)
        {
            if (!String.IsNullOrEmpty(category))
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    Category item = context.Category.First(p => p.Name == category);
                    if (item == null)
                    {
                        item = new Category();
                        item.Name = category;
                        context.Category.Add(item);
                        context.SaveChanges();
                    }
                    return item;
                }
            }
            return null;
        }
        public static Response CreateCategory(CreateCategoryRequest Request)
        {
            Response response = new Response();

            if (Request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        Category item = new Category();
                        item.Name = Request.Name;
                        item.Description = Request.Description;
                        item.Parent = Request.Parent;
                        context.Category.Add(item);
                        context.SaveChanges();
                        response.SetSUCCESS();
                    }
                    catch (Exception ex)
                    {
                        response.SetFAILED();
                        response.ResultMessage = GetInnerExceptionMessage(ex);
                    }
                }
            }

            return response;
        }
        #endregion

        public static CreateExpenseItemResponse CreateExpenseItem(CreateExpenseItemRequest Request)
        {
            CreateExpenseItemResponse response = new CreateExpenseItemResponse();
            if (Request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        ExpenseItem expenseItem = new ExpenseItem()
                        {
                            ProductName = Request.ProductName,
                            Price = Request.Price,
                            Qty = Request.Qty == 0 ? 1 : Request.Qty,
                            Date = DateTime.Now,
                            Value = Request.Qty * Request.Price
                        };

                        CategoryTags tags;
                        if (!String.IsNullOrEmpty(Request.ProductCategory))
                        {
                            tags = context.CategoryTags.FirstOrDefault(p => p.Tag.Contains(Request.ProductName));
                            if (tags == null)
                            {
                                tags = new CategoryTags();
                                tags.CategoryName = Request.ProductCategory;
                                tags.Tag = Request.ProductName;
                                context.CategoryTags.Add(tags);
                            }
                            
                        }
                        else
                        {
                            tags = context.CategoryTags.FirstOrDefault(p => p.Tag.Contains(Request.ProductName));
                        }
                        if (tags != null)
                        {
                            expenseItem.ProductCategory = tags.CategoryName;
                        }

                        if (String.IsNullOrEmpty(expenseItem.ProductCategory))
                        {
                            expenseItem.ProductCategory = "empty";
                        }
                        context.ExpenseItem.Add(expenseItem);
                        if (context.SaveChanges() > 0)
                        {
                            response.SetSUCCESS(expenseItem);
                        }
                        else
                        {
                            response.SetFAILED();
                        }
                    }
                    catch (Exception ex)
                    {
                        response.SetFAILED(ex.Message);
                    }
                }
            }
            return response;
        }

        public static Response CreateCategoryTags(CategoryTagsRequest Request)
        {
            Response response = new Response();
            if (Request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        CategoryTags item = new CategoryTags();
                        item.Tag = Request.Tag;
                        item.CategoryName = Request.Category;
                        
                        context.CategoryTags.Add(item);
                        context.SaveChanges();
                        response.SetSUCCESS(item.Id.ToString());
                    }
                    catch (Exception ex)
                    {
                        response.SetFAILED(ex.Message);
                    }
                }
            }
            else
            {
                response.SetFAILED("Request is null");
            }
            return response;
        }

        
        public static string GetInnerExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetInnerExceptionMessage(ex.InnerException);
            }
            else
            {
                return ex.Message;
            }
        }
        public static Response CreateUser(CreateUserRequest request)
        {
            Response response = new Response();
            if (response != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        Users u = context.Users.Find(request.UserId);
                        if (u == null)
                        {
                            Users user = new Users();
                            user.UserId = request.UserId;
                            user.UserName = request.UserName;
                            user.Token = request.Token;
                            context.Users.Add(user);
                            context.SaveChanges();
                            response.SetSUCCESS();
                        }
                        else
                        {
                            response.SetFAILED(String.Format("User {0} already exists", request.UserId));
                        }
                    }
                    catch (Exception ex)
                    {
                        response.SetFAILED(ex.Message);
                    }
                }
            }
            return response;
        }

        public static Response AuthUser(AuthUserRequest request)
        {
            Response response = new Response();
            
            using (ExpensesEntities context = new ExpensesEntities())
            {
                try
                {
                    Users user = context.Users.Find(request.UserId);
                    if (user != null)
                    {
                        if (!String.IsNullOrEmpty(user.Token))
                        {
                            if (user.Token.Equals(request.Token))
                            {
                                response.SetSUCCESS();
                            }
                            else
                            {
                                response.SetFAILED("Password is incorrect");
                            }
                        }
                        else
                        {
                            response.SetSUCCESS();
                        }
                    
                    }
                    else
                    {
                        response.SetFAILED("User does not exists");
                    }
                }
                catch (Exception ex)
                {
                    response.SetFAILED(ex.Message);
                }
            }
            return response;
        }

        public static ExpenseItemsResponse GetExpenseItems(ExpenseItemsRequest request)
        {
            ExpenseItemsResponse response = new ExpenseItemsResponse();
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    IQueryable<ExpenseItem> items =
                        from item in context.ExpenseItem
                        where
                            (
                                ((item.Date >= request.StartDate)) &&
                                ((item.Date <= request.EndDate))
                            )
                        orderby item.Date descending
                        select item;
                            
                    
                    response.Items = items.ToList();
                    //if (items != null)
                    //{
                    //    response.Items = items.ToList<ExpenseItem>();        
                    //}                    
                }
            }
            return response;
        }

        public static ExpenseCategoryResponse GetExpenseCategory(ExpenseCategoryRequest request)
        {
            ExpenseCategoryResponse response = new ExpenseCategoryResponse();

            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    IEnumerable<ExpenseCategoryGroupSum> items =
                        from item in context.ExpenseItem
                        where
                        (
                            ((item.Date >= request.BeginDate) || (request.BeginDate == null)) &&
                            ((item.Date <= request.EndDate) || (request.EndDate == null))
                        )
                        group item by
                            new ExpenseCategoryGroup { CategoryName = item.ProductCategory, Year = item.Date.Year, Month = item.Date.Month }
                            into grc
                            select new ExpenseCategoryGroupSum
                                {
                                    CategoryName = grc.Key.CategoryName,
                                    Year = grc.Key.Year,
                                    Month = grc.Key.Month,
                                    Value = grc.Sum(p => p.Value),
                                    ValuePlanned = grc.Sum(p => p.ValuePlan)
                                };

                    response.Items = items.ToList();                             
                }
            }
            return response;
        }

        public static ResponseTest GetExpenseCategoryTest(ExpenseCategoryRequest request)
        {
            ResponseTest response = new ResponseTest();
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    var items = from item in context.ExpenseItem
                                group item by item.ProductCategory into groupCat
                                select new
                                {
                                    groupCat.Key,
                                    Value = groupCat.Sum(p => p.Value)
                                    //YearGroup = from year in groupCat
                                    //            group year by year.Date.Year into groupYear
                                    //            select new
                                    //            {
                                    //                Year = groupYear.Key,
                                    //                MonthGroup = from month in groupYear
                                    //                             group month by month.Date.Month into monthGroup
                                    //                             select new
                                    //                             {
                                    //                                 Month = monthGroup.Key,
                                    //                                 Value = monthGroup.Sum(p => p.Value)
                                    //                             }
                                    //            }
                                };
                    response.Items = items.ToList<object>();
                }
            }
            return response;
        }
        public static Response CreateExpenseCategoryBatch(CreateExpenseCategoryBatchRequest request)
        {
            Response response = new Response();
            response.SetFAILED();
            int counter;
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        counter = 0;
                        foreach (CreateExpenseCategoryRequest item in request.Requests)
                        {
                            ExpenseCategory cat = new ExpenseCategory();
                            Category category = context.Category.Where(p => p.Name == item.CategoryName).FirstOrDefault();
                            if (category == null)
                            {
                                category = new Category() { Name = item.CategoryName };
                                context.Category.Add(category);
                            }
                            cat.CategoryName = category.Name;
                            cat.Account = item.Account;
                            cat.Date = item.Date;
                            if (item.Planned)
                            {
                                cat.ValuePlan = item.Value;
                            }
                            else
                            {
                                cat.Value = item.Value;
                            }
                            context.ExpenseCategory.Add(cat);
                            counter++;
                        }
                        context.SaveChanges();
                        response.SetSUCCESS();
                        response.ResultMessageText = String.Format("Zapisano {0} rekordów", counter);
                    }
                    catch (Exception ex)
                    {
                        response.ResultMessageText = ex.Message;
                    }
                }
            }
            return response;
        }
        private static void AddExpenseCategory(CreateExpenseCategoryRequest request)
        {
            
        }
        public static Response CreateExpenseCategory(CreateExpenseCategoryRequest request)
        {
            Response response = new Response();
            response.SetFAILED();
            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    try
                    {
                        ExpenseCategory item = new ExpenseCategory();
                        Category category = context.Category.Where(p => p.Name == request.CategoryName).FirstOrDefault();
                        if (category == null)
                        {
                            category = new Category() { Name = request.CategoryName };
                            context.Category.Add(category);
                        }
                        item.CategoryName = category.Name;
                        item.Account = request.Account;
                        //item.CategoryName = request.CategoryName;
                        item.Date = request.Date;
                        if (request.Planned)
                        {
                            item.ValuePlan = request.Value;
                        }
                        else
                        {
                            item.Value = request.Value;
                        }
                        context.ExpenseCategory.Add(item);
                        context.SaveChanges();
                        response.ResultPayload = item;
                        response.SetSUCCESS();
                    }
                    catch (Exception ex)
                    {                        
                        response.ResultMessageText = ex.Message;

                    }
                }
            }
            return response;
        }

        public static ExpenseCategoryResponse GetExpenseCategorySum(ExpenseCategoryRequest request)
        {
            ExpenseCategoryResponse response = new ExpenseCategoryResponse();

            if (request != null)
            {
                using (ExpensesEntities context = new ExpensesEntities())
                {
                    IEnumerable<ExpenseCategoryGroupSum> items =
                        from item in context.ExpenseCategory
                        where
                        (
                            ((item.Date >= request.BeginDate) || (request.BeginDate == null)) &&
                            ((item.Date <= request.EndDate) || (request.EndDate == null)) 
                        )
                        group item by
                            new ExpenseCategoryGroup { CategoryName = item.CategoryName, Year = item.Date.Year, Month = item.Date.Month }
                            into grc
                            select new ExpenseCategoryGroupSum
                            {
                                CategoryName = grc.Key.CategoryName,
                                Year = grc.Key.Year,
                                Month = grc.Key.Month,
                                Value = grc.Sum(p => p.Value),
                                ValuePlanned = grc.Sum(p => p.ValuePlan)
                            };
                    response.Items = items.ToList();
                }
                    
            }

            return response;
        }
    }
}