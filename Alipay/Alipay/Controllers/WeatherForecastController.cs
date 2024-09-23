using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace Alipay.Controllers
{
    [ApiController]
    [Route("alipay")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("/pay-result")]
        public async Task<IActionResult> GetAlipayResult() 
        {
            IAopClient alipayClient = new DefaultAopClient(GetAlipayConfig());
            // 构造请求参数以调用接口
            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            AlipayTradeQueryModel model = new AlipayTradeQueryModel();

            // 设置订单支付时传入的商户订单号
            model.OutTradeNo = "20150320010101001";

            // 设置支付宝交易号
            model.TradeNo = "2014112611001004680 073956707";

            // 设置查询选项
            List<String> queryOptions = new List<String>();
            queryOptions.Add("trade_settle_info");
            model.QueryOptions = queryOptions;

            request.SetBizModel(model);
            // 第三方代调用模式下请设置app_auth_token
            // request.PutOtherTextParam("app_auth_token", "<-- 请填写应用授权令牌 -->");

            AlipayTradeQueryResponse response = alipayClient.Execute(request);

            if (!response.IsError)
            {
                return Ok(response);
            }
            else
            {
                return Ok("failed");
            }
        }

        [HttpGet("/pay/")]

        public async Task<IActionResult> PostAlipay() 
        {
            // 初始化SDK
            IAopClient alipayClient = new DefaultAopClient(GetAlipayConfig());
            // 构造请求参数以调用接口
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();

            // 设置商户门店编号
            model.StoreId = "NJ_001";

            // 设置订单绝对超时时间
            model.TimeExpire = "2024-12-31 10:05:01";
            model.TimeoutExpress = "2024-12-31 10:05:00";

            // 设置业务扩展参数
            ExtendParams extendParams = new ExtendParams();
            extendParams.SysServiceProviderId = "2088511833207846";
            extendParams.HbFqSellerPercent = "100";
            extendParams.HbFqNum = "3";
            extendParams.IndustryRefluxInfo = "{\"scene_code\":\"metro_tradeorder\",\"channel\":\"xxxx\",\"scene_data\":{\"asset_name\":\"ALIPAY\"}}";
            extendParams.SpecifiedSellerName = "XXX";
            extendParams.RoyaltyFreeze = "true";
            extendParams.CardType = "S0JP0000";
            model.ExtendParams = extendParams;

            // 设置订单标题
            model.Subject = "SS";

            // 设置请求来源地址
            //model.RequestFromUrl = "https://";

            // 设置产品码
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";

            // 设置PC扫码支付的方式
            model.QrPayMode = "1";

            // 设置商户自定义二维码宽度
            model.QrcodeWidth = 100;

            // 设置请求后页面的集成方式
            model.IntegrationType = "PCWEB";

            // 设置订单包含的商品列表信息
            List<GoodsDetail> goodsDetail = new List<GoodsDetail>();
            GoodsDetail goodsDetail0 = new GoodsDetail();
            goodsDetail0.GoodsName = "ipad";
            goodsDetail0.AlipayGoodsId = "20010001";
            goodsDetail0.Quantity = 1;
            goodsDetail0.Price = "2000";
            goodsDetail0.GoodsId = "apple-01";
            goodsDetail0.GoodsCategory = "34543238";
            goodsDetail0.CategoriesTree = "124868003|126232002|126252004";
            goodsDetail0.ShowUrl = "http://www.alipay.com/xxx.jpg";
            goodsDetail.Add(goodsDetail0);
            model.GoodsDetail = goodsDetail;


            // 设置商户的原始订单号
            string merchantOrderNo = $"{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
            model.MerchantOrderNo = merchantOrderNo;

            // 设置二级商户信息
            SubMerchant subMerchant = new SubMerchant();
            subMerchant.MerchantId = "2088721039602372";
            subMerchant.MerchantType = "alipay";
            model.SubMerchant = subMerchant;

            // 设置开票信息
            InvoiceInfo invoiceInfo = new InvoiceInfo();
            InvoiceKeyInfo keyInfo = new InvoiceKeyInfo();
            keyInfo.TaxNum = "1464888883494";
            keyInfo.IsSupportInvoice = true;
            keyInfo.InvoiceMerchantName = "ABC|003";
            invoiceInfo.KeyInfo = keyInfo;
            invoiceInfo.Details = "[{\"code\":\"100294400\",\"name\":\"服饰\",\"num\":\"2\",\"sumPrice\":\"200.00\",\"taxRate\":\"6%\"}]";
            model.InvoiceInfo = invoiceInfo;

            // 设置商户订单号
            string outTradeNo = $"{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
            model.OutTradeNo = outTradeNo;

            // 设置外部指定买家
            ExtUserInfo extUserInfo = new ExtUserInfo();
            extUserInfo.CertType = "IDENTITY_CARD";
            extUserInfo.CertNo = "362334768769238881";
            extUserInfo.Name = "dssbda8571";
            extUserInfo.Mobile = "16587658765";
            extUserInfo.MinAge = "18";
            extUserInfo.NeedCheckInfo = "F";
            extUserInfo.IdentityHash = "27bfcd1dee4f22c8fe8a2374af9b660419d1361b1c207e9b41a754a113f38fcc";
            model.ExtUserInfo = extUserInfo;

            // 设置订单总金额
            model.TotalAmount = "88.88";

            // 设置商户传入业务信息
            model.BusinessParams = "{\"mc_create_trade_ip\":\"127.0.0.1\"}";

            // 设置优惠参数
            model.PromoParams = "{\"storeIdType\":\"1\"}";

            request.SetBizModel(model);
            // 第三方代调用模式下请设置app_auth_token
            // request.PutOtherTextParam("app_auth_token", "<-- 请填写应用授权令牌 -->");

            //AlipayTradePagePayResponse response = alipayClient.pageExecute(request, null, "POST");
            // 如果需要返回GET请求，请使用
            AlipayTradePagePayResponse response = alipayClient.pageExecute(request, null, "GET");
            
            
    
            if (!response.IsError)
            {
                //string decodedResponse = HttpUtility.HtmlDecode(response.Body);
                return Ok(response);
            }
            else
            {
                Trace.WriteLine($"Error Code: {response.Code}, Error Message: {response.Msg}");
                return Ok("failed");
            }
        }

        private static AlipayConfig GetAlipayConfig()
        {
            string privateKey = "MIIEpQIBAAKCAQEAhXjwCDmL+ghNnuUOJmvawo+y5eCkMNZdHtwTfgtSzcJNXrj6z3S564RAf9PNAgZI87QKm1oVzfipar8DO+IJTnkpnslz8LWOXT5CUjQdwSh5x7Yplpk3uLkAX3cmgNJ+XhOFGv6smLKCa7jSXG3lhpc9qmFRzq2f2KvBTshoeYt391UstTV2FUdzu74+z5pzQNw+yr6tPPasYFPvJY4T1ogpJknMP5sUbwc3dIEa+IJpxMHJZuwXbh0TzqcqHtY0VgNgB6fRze1PN3QlAK3dqaYS4M9AMDwi/0WkO/iDS1qIoP9g+UZ0Gto/rFhHmM3JvE9lbDmdu6MioJK6w1WWVwIDAQABAoIBAEuOxvMhAKiugqJssLH3ZIO3rWKM5OXwtA6AL1ivOFTapcn1laZTQdydpZW3ZNq8jBfJ2CdRu/45wk53i3Ee6H3QAUuuZz/gx5LpZ8n5Ts7GBwqTiL+ERRMBR8DDRryubHL9QeCiQzq98y7gFdXVMJYckAAfz5vclhymPmxG7z2+cDQ56zOelXHE9Kz7yGs87e4x5R3a5VecjQYZUzAUEJ0j6DN7tKlJ8o5gOU+hVSjTumxnxsE+BVCJ42eiQ88Q43FSK39d8G4b1B/P+R9o4Oqc0uw4SM+KDsyV5sQgBpU/mvkry0IHybv85zHissPi5Q95cN/hzqDcC85tr+N+y4ECgYEAyfNpCEQ1r6DnCaD4p2E/6DxDq3V54p1W7gPsCEwD3fST6LWgLCptTlugQ7LK/Z4UKGVWA4RwwxiR8QIEHzQwRQlS8EydogillWF9TEwi6arqTnClzrb0szdgEi5VYdASrc2oyuCkDwSuL94CnPiF6ukkyjg06KDjdIDlGb4k4UcCgYEAqTHA0AbVQyBQlQnZZkCxM835g+fis+sLcEltfvMaiCAiwBJZsQzviMyWEcKTjXtFFGjfe4U2XUJdwplewux+Hd/8Kwxs6sSBbKNX25uMzNUne9cQbfg5Zi9eTVcXj6Dw6OyhGzQhsVKEeUAe7dgwZyhorb3zN/hsEmizTH9jqnECgYEAyQRi3fmXPrR4hJsYJvOkOzQRX4/VvP5EUzLQNQoFJ1+WAqMXRh8NIlwN0JUdfQlmozcLQQEJhQjl6/HHzI+UJIO9bLe2iFz3BRQ/Njzq25BnHaD/Sh3OwL00AaThFDWbAimeBCNK6jAMelUQYNL36fYbyrXb5FqRTZwnb1JXP20CgYEAgL9ZZ3MrqU7XwvGhusuTjEY6joNP4XUEWUemyKmZEOjTSLEuCyo6xDBaKd2Uhl69LFC5brbprYGo80Hd+BoZxgYBT4i/AM7TZaXOX1A4jk3NI9F9sRDoLLfy3ItfZG4lpDkcRyUeVl7ia5m9b2PJQVZggYU/pOGm60M83QM7BiECgYEAlHAsQ3deUDT2YM7cap8N7nyRKvf2YsxzfehcjOLHpHlwiGxokk/yw5B/TDaz6eep3i958rj1lYRHw92XJr5ZWHQI6axBp63fkVM/uvirBBxm8ccGUCCh21eCwJL/BmqLMgMB847qqkfyjAlCVdES9+uj08yA6Iszxx/qTfjdUcY=";
            string alipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkMygCtIR6ifhOjXnxll69l0BeomijILjll+1FatSGYXnqk8gqOyyMinq43nSiUfzBdvI8UdDiBQiP1W6/wdoQSA+rpdoXE7TTse3MnL4SFqmLztCMR3FLTdEVRA9zAUVeByXgQ9QYp3U0+IG4zDHaDdw7crqqNAZaukazBlv4Z76viASFeRC0/FzIPNfimGfryTwVKMSW9HYZyIPzQ5f6rMdcobpLhL/qTF8tFTQ71yIwKPjeYM0IUJi6T7bADynBKptI+kEN0GAs97bNPd9sf92hD7yKxbSrpgdlIPBl7ExkY4v5OicMh0skjmRsKajls6QwQiXd0DXo3jq2QT3KwIDAQAB";
            AlipayConfig alipayConfig = new AlipayConfig();
            alipayConfig.ServerUrl = "https://openapi-sandbox.dl.alipaydev.com/gateway.do";
            alipayConfig.AppId = "9021000139624960";
            alipayConfig.PrivateKey = privateKey;
            alipayConfig.Format = "json";
            alipayConfig.AlipayPublicKey = alipayPublicKey;
            alipayConfig.Charset = "UTF-8";
            alipayConfig.SignType = "RSA2";
            
            return alipayConfig;
        }
    }
}
