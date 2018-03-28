using System;
using Sitecore.EmailCampaign.Cm.Pipelines.SendEmail;
using Sitecore.Modules.EmailCampaign.Core;

namespace Sitecore.Support.EmailCampaign.Cm.Pipelines.SendEmail
{
  public class SendEmail : Sitecore.EmailCampaign.Cm.Pipelines.SendEmail.SendEmail
  {
    public SendEmail(Sitecore.ExM.Framework.Diagnostics.ILogger logger) : base(logger)
    {
    }

    public SendEmail(Sitecore.ExM.Framework.Diagnostics.ILogger logger, Sitecore.EDS.Core.Dispatch.IDispatchManager dispatchManager, Sitecore.EmailCampaign.Model.Web.Settings.EcmSettings exmSettings) : base(logger, dispatchManager, exmSettings)
    {
    }

    public new void Process(SendMessageArgs args)
    {
      base.Process(args);
      if (args.IsTestSend && args.StartSendTime > DateTime.MinValue)
      {
        EcmGlobals.GenerationSemaphore.ReleaseOne();
      }
    }
  }
}