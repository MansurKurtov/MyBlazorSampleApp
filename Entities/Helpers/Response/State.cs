using Microsoft.AspNetCore.Mvc;

namespace Entity.Helpers.Response
{
        public static class State
        {
            public static ResponseData GetResponse(this ControllerBase cBase,
                object result = null,
                ResponseStatus code = ResponseStatus.OK
                )
            {
                    var model = new ResponseData(result, code);
                    cBase.Response.StatusCode = model.StatusCode;
                    return model;
                //cBase.HttpContext.Response.StatusCode = status;
            }
           
           
        }

}
