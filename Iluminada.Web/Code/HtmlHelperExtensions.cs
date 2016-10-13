using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iluminada.Web.Code
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ToJson(this HtmlHelper @this, object value)
        {
            return new HtmlString(JsonConvert.SerializeObject(value));
        }

        public static HtmlString ToJson(this HtmlHelper @this, object value, Formatting formatting)
        {
            return new HtmlString(JsonConvert.SerializeObject(value, formatting));
        }
    }
}