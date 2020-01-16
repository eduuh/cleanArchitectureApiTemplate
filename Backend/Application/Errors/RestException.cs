using System;
using System.Net;
namespace Application.Errors {
    public class RestException : Exception {

        public HttpStatusCode Code {get; set;}
        public Object Errors {get; set;}
        public RestException (HttpStatusCode code, object obj = null) {
            Code= code;
            Errors= obj;
        }

    }

}