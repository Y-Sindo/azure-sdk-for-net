// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FunctionApp
{
    public class NewConnection
    {
        public string ConnectionId { get; }

        public NewConnection(string connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}
