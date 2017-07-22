# Wlitsoft.Framework.WeixinSDK
[![Build status](https://ci.appveyor.com/api/projects/status/7yx2eghboc3hvhml?svg=true)](https://ci.appveyor.com/project/Wlitsoft/weixinsdk)

Wlitsoft 框架 - 微信公众号开发工具包

## NuGet

包名称  | 当前版本 |
-------- | :------------ |
Wlitsoft.Framework.WeixinSDK | [![NuGet](https://img.shields.io/nuget/v/Wlitsoft.Framework.WeixinSDK.svg)](https://www.nuget.org/packages/Wlitsoft.Framework.WeixinSDK)
Wlitsoft.Framework.WeixinSDK.Config | [![NuGet](https://img.shields.io/nuget/v/Wlitsoft.Framework.WeixinSDK.Config.svg)](https://www.nuget.org/packages/Wlitsoft.Framework.WeixinSDK.Config)
Wlitsoft.Framework.TokenService.Distributed | [![NuGet](https://img.shields.io/nuget/v/Wlitsoft.Framework.TokenService.Distributed.svg)](https://www.nuget.org/packages/Wlitsoft.Framework.TokenService.Distributed)

## 关于项目

​       该项目的背景是现在微信公众号、微信服务号乃至微信小程序开发非常普遍了已经，以上种种开发均需要和微信打交道，但是微信官方没有提供原始的 .Net 版的 SDK 供我们使用，并且官方提供的示例亦 Bug 连连，所以决定成立该开源项目。

        现在已经有些非常优秀的 .Net 版的 WeixinSDK ，并且功能非常的全面、扩展性亦非常的好，那么大家要问了 为什么还要重复造轮子呢，这个问道点上了，我所有的开源项目第一是为了项目使用，再一个原因是为了大家学习，所有所有的项目每个类均有完整的代码注释，每个类亦有对应的单元测试。并且代码易于理解，接口或抽象亦于扩展。

## 项目依赖

该项目依赖了一些基本的组件，这些组件也是几个开源项目：

- Wlitsoft.Framework.Common 【公共类库】
- Wlitsoft.Framework.Common.Serializer.JsonNet 【基于 Json.Net 的序列化实现】
- Wlitsoft.Framework.Common.Logger.Log4Net 【基于 log4net 的日志记录者】
- Wlitsoft.Framework.Caching.Redis 【分布式缓存 Redis 实现】

## 基本 API

- 微信令牌、js 令牌获取；
- 微信模板消息；
- OAuth2 授权相关接口；
- 用户管理相关接口。



## 令牌服务

- TokenServiceBase 令牌服务基类，提供所有令牌服务的基本实现以及抽象。
- GeneralTokenService 基本的令牌服务，使用本地缓存加定时器实现的基本令牌服务，如果是单机单站点的应用可以使用此令牌服务。
- DebugTokenService 调试令牌服务，该令牌服务主要应用于调试场景，直接指定一个 Token 即可调用 WeixinSDK 中的接口。
- DistributedTokenService 分布式令牌服务，使用分布式缓存实现的令牌服务，主要应用于多机多站点的场景。

### 配置令牌服务

需要在应用程序启动代码里面执行一次即可

​	GeneralTokenService tokenService = new GeneralTokenService();

​	App.Builder.SetWeixinTokenService(tokenService);



## 微信消息处理

微信给我们开放了一些开发能力，比如接收微信的一些事件（关注事件、取消关注事件、按钮点击事件等）消息、接收普通文本消息、语音消息等功能。

该 SDK 中针对微信消息处理模块开发了一个简单的消息处理框架，只需要按照指定的写法写一些实现类即可。

- WeixinSDK/src/WeixinSDK/Message/Request/ 请求消息相关实体。
- WeixinSDK/src/WeixinSDK/Message/Response/ 响应消息相关实体。
- WeixinSDK/src/WeixinSDK/Message/Process/ 微信消息处理逻辑。

## 配置消息处理

1. 硬编码方式配置

   ```c#
   MessageProcessConfiguration pc = new MessageProcessConfiguration();
   pc.MessageList.Add(new MessageConfiguration<RequestTextMessageProcessFake>(RequestMsgType.Text));

   App.Builder.SetWeixinMessageConfig(pc);
   ```



2. 配置文件方式配置



```json
{
  "Messages": [
    {
      "MsgType": "Text",
      "Type": "WeixinSDK.Config.Test.Fake.MessageProcessDemo01,WeixinSDK.Config.Test"
    }
  ],
  "EventMessages": [
    {
      "EventType": "Subscribe",
      "EventKey": "Key01",
      "Type": "WeixinSDK.Config.Test.Fake.EventMessageProcessDemo01,WeixinSDK.Config.Test"
    }
  ]
}
```

`App.Builder.SmtWeixinMessageProcessConfigByJsonFile("./xxxx.json");`



### 微信消息处理示例类

```c#
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Request.Event;
using Wlitsoft.Framework.WeixinSDK.Message.Response;

namespace WeixinSDK.Test.Fake
{
    /// <summary>
    /// 订阅事件消息 Key_001 请求处理。
    /// </summary>
    public class RequestSubscribeEventMessageKey_001ProcessFake : WeixinMessageProcessBase
    {
        #region WeixinMessageProcessBase 成员

        /// <summary>
        /// 执行处理。
        /// </summary>
        public override void Process()
        {
            RequestSubscribeEventMessage requestMessage = base.GetRequestMessage<RequestSubscribeEventMessage>();

            ResponseTextMessage responseMessage = new ResponseTextMessage()
            {
                Content = requestMessage.EventKey
            };

            base.ResponseMessage = responseMessage;
        }

        #endregion
    }
}
```