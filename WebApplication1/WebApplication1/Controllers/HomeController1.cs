using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController1 : Controller
    {
        [Route("bookStore/{bookId?:int}/{testing?:string}")]
        public ActionResult Index([FromQuery] int? bookId, [FromRoute] string? testing, [FromForm] firstEndpointPayload firstEndpointPayload)
        {
            if (!ModelState.IsValid)                // through this Property ( Model State ) we can access the error messages of Model. Also we can check the whole Model.
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToString());
            }
            return Ok();
        }
    }

    public class firstEndpointPayload               // when we have applied the validations on the model it self related to the parameters then we call that thing is MODEL VALIDATIONS
    {
        [Required]
        public int BookId { get; set; }
        [Required(ErrorMessage = "testing can not be empty")]       // through this we can add the validation and shows the error message in the response of the endpoint
        public int Testing { get; set; }
        [DisplayName("Cust Name")]
        public string CustomerName { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 2)]        // here are some of validation attributes
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }

    }
}

//Model binding always executes according to Higher to lower preferences :- FORM FIELDS , REQUEST BODY , ROUTE DATA & QUERY STRING PARAMETERS
// in the Model binding we can specify that from where we want to pick the value :- [FromQuery] int x , [FromRoute] string z. Here we are taking the individual parameters but we can do this 
// same thing by creating a class and then by adding these parameters in that class.
// [FromRoute] string? testing :- By adding the ? we can make that parameter as optional parameter
// Model Validations :- The attributes which I have added in firstEndpointPayload class properties those are called Model Validations
//                   :- Model State property also have internally 3 props :- IsValid ( Specifies whether there is at least one validation error or not )
//                                                                        :- ErrorCount ( Return the Number of Errors )
//                                                                        :- Values ( It contains each model property value with corresponding "Errors" )