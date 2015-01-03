using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "ResponseTest", Namespace = "http://butterfly.service/expenses")]
    public class ResponseTest
    {
        public List<object> Items { get; set; }
    }
    [DataContract(Name="Response", Namespace="http://butterfly.service/expenses")]
    public class Response
    {
        private int resultCode;
        private string resultMessage;
        private string resultMessageText;
        private object resultPayload;
        
        public Response()
        {
            this.resultCode = 1;
            this.resultMessage = String.Empty;
            this.resultMessageText = String.Empty;
            this.resultPayload = null;
        }
        [DataMember(Order = 3)]
        public object ResultPayload
        {
            get { return resultPayload; }
            set { resultPayload = value; }
        }
        [DataMember(Order=2)]        
        public string ResultMessageText
        {
            get { return resultMessageText; }
            set { resultMessageText = value; }
        }
        [DataMember(Order = 1)]
        public string ResultMessage
        {
            get { return resultMessage; }
            set { resultMessage = value; }
        }
        [DataMember(Order = 0)]
        public int ResultCode
        {
            get { return resultCode; }
            set { resultCode = value; }
        }
        public virtual void SetSUCCESS(object obj)
        {
            this.SetSUCCESS();
        }
        public void SetSUCCESS()
        {
            this.resultCode = (int)ResultCodeEnum.SUCCESS;
            this.resultMessage = ResultCodeTranslate.GetMessage(ResultCodeEnum.SUCCESS);
        }
        public void SetSUCCESS(string resultMessageText)
        {
            this.SetSUCCESS();
            this.resultMessageText = resultMessageText;
        }
        public virtual void SetFAILED(object obj)
        {
            this.SetFAILED();
        }
        public void SetFAILED()
        {
            this.resultCode = (int)ResultCodeEnum.FAILED;
            this.resultMessage = ResultCodeTranslate.GetMessage(ResultCodeEnum.FAILED);
        }
        public void SetFAILED(string resultMessageText)
        {
            this.SetFAILED();
            this.resultMessageText = resultMessageText;
        }
        //public static Response Create(ResultCodeEnum resultCode, string resultMessageText)
        //{
        //    return Response.Create(resultCode, ResultCodeTranslate.GetMessage(resultCode), resultMessageText);
        //}
        //public static Response Create(ResultCodeEnum resultCode, string resultMessage, string resultMessageText, Exception exception = null)
        //{
        //    return new Response() { ResultCode = (int)resultCode, ResultMessage = resultMessage, ResultMessageText = resultMessageText };
        //}
        //public static Response CreateOK(string resultMessageText = "")
        //{
        //    return Response.Create(ButterflyService.ResultCodeEnum.SUCCESS, resultMessageText);
        //}
        //public static Response CreateFAILED(string resultMessageText = "")
        //{
        //    return Response.Create(ButterflyService.ResultCodeEnum.FAILED, resultMessageText);
        //}

    }

    public enum ResultCodeEnum
    {
        SUCCESS,
        FAILED
    }

    public static class ResultCodeTranslate
    {
        public static string GetMessage(ResultCodeEnum resultCode)
        {
            switch (resultCode)
            {
                case ResultCodeEnum.SUCCESS: return ConfigurationManager.AppSettings["messageOK"];
                case ResultCodeEnum.FAILED: return ConfigurationManager.AppSettings["messageFAIL"];
            }
            return String.Empty;
        }
    }
}