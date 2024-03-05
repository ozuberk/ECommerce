using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO
{
    public class ApiDTO<TEntity>
    {
        public TEntity Data { get; set; }

        [JsonIgnore]
        public int StatuCode { get; set; }

        public List<string> Errors { get; set; }

        public static ApiDTO<TEntity> Success(int statuCode, TEntity data)
        {
            return new ApiDTO<TEntity> { Data = data, StatuCode = statuCode };
        }

        public static ApiDTO<TEntity> Success(int statuCode)
        {
            return new ApiDTO<TEntity> { StatuCode = statuCode };
        }

        public static ApiDTO<TEntity> Fail(int statuCode, List<string> errors)
        {
            return new ApiDTO<TEntity> { StatuCode = statuCode, Errors = errors };
        }

        public static ApiDTO<TEntity> Fail(int statuCode, string error)
        {
            return new ApiDTO<TEntity> { StatuCode = statuCode, Errors = new List<string> { error } };
        }
    }
}
