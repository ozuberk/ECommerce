using ECommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class BaseController : Controller
    {

        [NonAction]
        public IActionResult SelectResponseResult<TEntity>(ApiDTO<TEntity> responseDTO)
        {


            switch (responseDTO.StatuCode)
            {
                case 204:

                    return new ObjectResult(null)
                    {
                        StatusCode = responseDTO.StatuCode
                    };

                default:
                    return new ObjectResult(responseDTO)
                    {
                        StatusCode = responseDTO.StatuCode

                    };
            }
        }


        [NonAction]
        public IActionResult ResultAPI<TEntity>(List<TEntity> tEntity)
        {
            try
            {
                if (tEntity.Count > 0)
                {
                    return SelectResponseResult(ApiDTO<List<TEntity>>.Success(200, tEntity));
                }

                else if (tEntity.Count == 0)
                {
                    return SelectResponseResult(ApiDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(ApiDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(ApiDTO<List<TEntity>>.Success(204, tEntity));
            }
        }

        [NonAction]
        public IActionResult ResultAPI<TEntity>(TEntity tEntity)
        {
            try
            {
                if (tEntity != null)
                {
                    return SelectResponseResult(ApiDTO<TEntity>.Success(200, tEntity));
                }

                else if (tEntity == null)
                {
                    return SelectResponseResult(ApiDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(ApiDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(ApiDTO<TEntity>.Success(204, tEntity));
            }
        }

    }
}
