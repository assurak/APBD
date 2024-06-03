using cw10.Models;

namespace cw10.ResponseModels;

public class GetAccountResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string role { get; set; }
    public List<CartResponseModel> cart{ get; set; }
}