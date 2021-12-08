// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace FunctionApp
{
    public class NewMessage
    {
        public string ConnectionId { get; }
        public string Sender { get; }
        public string Text { get; }

        public NewMessage(InvocationContext invocationContext, string message)
        {
            Sender = string.IsNullOrEmpty(invocationContext.UserId) ? string.Empty : invocationContext.UserId;
            ConnectionId = invocationContext.ConnectionId;
            Text = message;
        }
    }
}
