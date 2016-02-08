﻿// Copyright 2004-2012 Castle Project, Henrik Feldt &contributors - https://github.com/castleproject
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Runtime.Remoting.Messaging;
using Castle.Core.Logging;

namespace Castle.Transactions.Activities
{
	/// <summary>
	///   The call-context activity manager saves the stack of transactions on the call-stack-context. This is the recommended manager and the default, also.
	/// </summary>
	public class CallContextActivityManager : IActivityManager
	{
		const string Key = "Castle.Services.Transaction.Activity";

		public CallContextActivityManager()
		{
			CallContext.LogicalSetData(Key, null);
		}

		public Activity GetCurrentActivity()
		{
			var activity = (Activity) CallContext.LogicalGetData(Key);

			if (activity == null)
			{
				activity = new Activity(NullLogger.Instance);
				CallContext.LogicalSetData(Key, activity);
			}

			return activity;
		}
	}
}