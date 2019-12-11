using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.ExceptionFilter {
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter {
        private Logger _logger;

        public ExceptionFilterAttribute() {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void OnException(ExceptionContext filterContext) {
            if (!filterContext.ExceptionHandled) {
                _logger.Error("UntrackedError");
                filterContext.Result = new RedirectResult("/Shared/Error.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}