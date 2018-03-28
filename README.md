# UMengAopSdk 友盟服务器消端息推送

###### 特点

```
依照官方文档强类型参数方式
```

>   官方API文档地址 http://dev.umeng.com/sdk_integate/android_push_apidoc



---


## 使用方法


######     2.1  消息发送


    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);
    var request = new AndroidPushRequest
    {
        //Alias =  "c13d8e62cb9e5cea322f34e1e1a55407" ,
        //AliasType = "main",
        DeviceTokens = "AvXxX7s8qEapm2wVQjUtcxSPVvm9vDiSw6zB2AEgj59b",
        //FileId= "PF910811489472565783",
        PushType = PushTypeEnum.UniCast,
        Payload = new AndroidPushRequest.PayloadModel
        {
            DisplayType = AndroidPushRequest.PayloadModel.DisplayTypeEnum.Notification,
            Body = new AndroidPushRequest.PayloadModel.BodyModel
            {
                Text = "统统优品促销活动1",
                Title = "统统优品促销活动2",
                Ticker = "统统优品促销活动3",
                AfterOpen = AndroidPushRequest.PayloadModel.BodyModel.AfterOpenEnum.Go_Custom,
                Custom = JObject.FromObject(new { type = "system", link = "main", parameter = "" })
            }
        },
        Filter = null,
        ProductionMode = false,
        Description = "统统优品促销活动"
    };

    var response = client.Execute(request);

    if (response.Success && response.Data != null && !response.Data.IsError)
    {
        msgid = response.Data.Data.MsgId;
    }

######     2.2  任务状态查询

    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);
    var request = new QueryStatusRequest
    {
        TaskId = "uf22337148947576478600"
    };
    var response = client.Execute(request);

    if (response.Success && response.Data != null && !response.Data.IsError)
    {
        msgid = response.Data.Data.TaskId;
    }


    
    
    
######     2.3  任务取消

    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);
    var request = new TaskCancelRequest
    {
        TaskId = "uf22337148947576478600"
    };
    var response = client.Execute(request);

    if (response.Success && response.Data != null && !response.Data.IsError)
    {
        msgid = response.Data.Data.TaskId;
    }
    
    
    
######     2.4  文件上传接口
 
    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);
    var request = new UploadRequest
    {
        Content = string.Join("\n", new string[] { "AvXxX7s8qEapm2wVQjUtcxSPVvm9vDiSw6zB2AEgj59b", "AvXxX7s8qEapm2wVQjUtcxSPVvm9vDiSw6zB2AEgj59b" })
    };
    var response = client.Execute(request);

    if (response.Success && response.Data != null && !response.Data.IsError)
    {
        fileid = response.Data.Data.FileId;
    }


    
    
    
######     4.7  附录G 过滤条件示例

    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);

    var expresstion = new ExpressionModel();
    expresstion.AddExpress(new AppVersionExpression(AppVersionExpression.OperationEnum.GreaterEqual, "版本号"));
    expresstion.AddExpress(new ChannelExpression(ChannelExpression.OperationEnum.Yes, "渠道"));
    expresstion.AddExpress(new CountryExpression(CountryExpression.OperationEnum.Yes, "国家"));
    expresstion.AddExpress(new DeviceModelExpression(DeviceModelExpression.OperationEnum.Yes, "设备号"));
    expresstion.AddExpress(new LanguageExpression(LanguageExpression.OperationEnum.Yes, "语言"));
    expresstion.AddExpress(new LaunchFromExpression(LaunchFromExpression.OperationEnum.Yes, 10));
    expresstion.AddExpress(new ProvinceExpression(ProvinceExpression.OperationEnum.Yes, "省"));
    expresstion.AddExpress(new TagExpression(TagExpression.OperationEnum.Yes, TagExpression.LogicEnum.And, "用户标签"));

    var request = new AndroidPushRequest
    {
        //Alias =  "c13d8e62cb9e5cea322f34e1e1a55407" ,
        //AliasType = "main",
        DeviceTokens = "AvXxX7s8qEapm2wVQjUtcxSPVvm9vDiSw6zB2AEgj59b",
        PushType = PushTypeEnum.UniCast,
        Payload = new AndroidPushRequest.PayloadModel
        {
            DisplayType = AndroidPushRequest.PayloadModel.DisplayTypeEnum.Notification,
            Body = new AndroidPushRequest.PayloadModel.BodyModel
            {
                Text = "统统优品促销活动1",
                Title = "统统优品促销活动2",
                Ticker = "统统优品促销活动3",
            }
        },
        Filter = new FilterModel
        {
            Expression = expresstion
        },
        Description = "统统优品促销活动",
        ProductionMode = false
    };
    //var json = request.ToJSON("", "");

    var response = client.Execute(request);
    Assert.IsFalse(response.Data.IsError);
    if (response.Success && response.Data != null && !response.Data.IsError)
    {
        msgid = response.Data.Data.MsgId;
    }


    
    
######      IOS推送

    IAopClient client = new DefaultAopClient("http://msg.umeng.com", appkey, app_master_secret);
    var request = new IOSPushRequest
    {
        //Alias =  "c13d8e62cb9e5cea322f34e1e1a55407" ,
        //AliasType = "main",
        DeviceTokens = "AvXxX7s8qEapm2wVQjUtcxSPVvm9vDiSw6zB2AEgj59b",
        PushType = PushTypeEnum.UniCast,
        Payload = new IOSPushRequest.PayloadModel
        {
            Aps = new IOSPushRequest.PayloadModel.ApsModel
            {
                Alter = "统统优品促销活动1"
            }
        },
        Description = "统统优品促销活动",
        ProductionMode = false
    };
    var response = client.Execute(request);