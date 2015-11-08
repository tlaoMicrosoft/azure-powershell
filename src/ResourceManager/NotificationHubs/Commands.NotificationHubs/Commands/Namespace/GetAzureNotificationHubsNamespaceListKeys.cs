﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.NotificationHubs.Models;
using Microsoft.Azure.Management.NotificationHubs.Models;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{

    [Cmdlet(VerbsCommon.Get, "AzureRmNotificationHubsNamespaceListKeys"), OutputType(typeof(ResourceListKeys))]
    public class GetAzureNotificationHubsNamespaceListKeys : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Namespace AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRule { get; set; }

        protected override void ProcessRecord()
        {
            // Get a namespace ConnectionString for the specified AuthorizationRule
            var keys = Client.GetNamespaceListKeys(ResourceGroup, Namespace, AuthorizationRule);
            WriteObject(keys);
        }
    }
}
