using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API
{
    public static class Extension
    {
        public static IActionResult BadFormatModelStateResult(this Controller controller,
            Action<string> callback = null)
        {           
            var errors = controller.ModelState.Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => NormalizeFieldName(kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var response = new
            {
                message = "Validation failed. Please check your input.",
                errors
            };      

            return controller.StatusCode(StatusCodes.Status400BadRequest, response);
        }       
   
        private static string NormalizeFieldName(string fieldName)
        {
            if (fieldName == "model") return "body"; 
            return fieldName.StartsWith("$.") ? fieldName.Substring(2) : fieldName; 
        }

    }
}
