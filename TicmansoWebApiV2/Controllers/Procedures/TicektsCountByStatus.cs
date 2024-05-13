using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace TicmansoWebApiV2.Controllers.Procedures
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicektsCountByStatus : ControllerBase
    {
        [HttpGet("tickets/count/{supportUserId}")]
        public IActionResult GetTicketCountsByStatus(string supportUserId)
        {
            //using (var connection = new SqlConnection("Server=DESKTOP-LUFTS9G;DataBase=TicmansoPRO;Persist Security Info=True;User ID=BlazorAdmin;Password=m#Ilw8g35p>FJ&0;"))
            using (var connection = new SqlConnection("Server=88.12.111.123,1433;DataBase=TicmansoV2;Persist Security Info=True;User ID=BlazorAdmin;Password=m#Ilw8g35p>FJ&0;"))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_CountTicketsByStatusAndSupportUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SupportUserId", supportUserId);

                    command.Parameters.Add("@Status1Count", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Status2Count", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Status3Count", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int status1Count = (int)command.Parameters["@Status1Count"].Value;
                    int status2Count = (int)command.Parameters["@Status2Count"].Value;
                    int status3Count = (int)command.Parameters["@Status3Count"].Value;

                    var result = new
                    {
                        Status1Count = status1Count,
                        Status2Count = status2Count,
                        Status3Count = status3Count
                    };

                    return Ok(result);
                }
            }
        }

    }
}
