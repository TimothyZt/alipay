<>
  <form
    id="alipaysubmit"
    name="alipaysubmit"
    action="https://openapi-sandbox.dl.alipaydev.com/gateway.do?charset=UTF-8"
    method="POST"
    style="display:none;"
  >
    <input name="alipay_sdk" value="alipay-sdk-net-4.9.258.ALL" />
    <input name="app_id" value="9021000139624960" />
    <input
      name="biz_content"
      value='{"business_params":"{\"mc_create_trade_ip\":\"127.0.0.1\"}","integration_type":"PCWEB","merchant_order_no":"202409090718596999","out_trade_no":"202409090718591878","product_code":"FAST_INSTANT_TRADE_PAY","promo_params":"{\"storeIdType\":\"1\"}","qr_pay_mode":"1","qrcode_width":100,"store_id":"NJ_001","sub_merchant":{"merchant_id":"2088721039602372","merchant_type":"alipay"},"subject":"SS","time_expire":"2024-12-31 10:05:01","timeout_express":"2024-12-31 10:05:00","total_amount":"88.88"}'
    />
    <input name="charset" value="UTF-8" />
    <input name="format" value="json" />
    <input name="method" value="alipay.trade.page.pay" />
    <input name="sign_type" value="RSA2" />
    <input name="timestamp" value="2024-09-09 15:18:59" />
    <input name="version" value="1.0" />
    <input
      name="sign"
      value="LQTuyVU0oxgLkWM8AueohhxeSwX5PN0xgwKtGjtL4J4SFVLEll5Hgb3B2+JMudzXD3KMbXEKxU1bsrAPbwOjyYJpBWHpM+6+imUu57yIHBRYLo0VAMR0KPSyiGIidOsX4gjWy2WuU9cC1BFI2ma83IV1cibXXkeW7/+CpnhfAB3YoeM4ufFD2sVlAHOH3ZJqcWpi+TsP/Ti7D2yTRbZtbTpNWSIz5GdR8HGVG7Zv7KxS52G79Tv1sLND6/F6VntD35gWlktgj1LagCpOeiUTrzj/DY+22Ive0v83TAZE4FjhIKWcs8sin9B6A/+J8v0/0/LzJlSLb/xJyzsXV2px6w=="
    />
    <input type="submit" value="POST" style="display:none;">
  </form>
  <script>document.forms['alipaysubmit'].submit();</script>
</>;
