﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Up.NET.Api;
using Up.NET.Api.Accounts;
using Up.NET.Api.Categories;
using Up.NET.Api.Tags;
using Up.NET.Api.Transactions;
using Up.NET.Api.Utilities;
using Up.NET.Api.Webhooks;
using Up.NET.Api.Webhooks.Events;
using Up.NET.Api.Webhooks.Logs;
using Up.NET.Models;

namespace UpBlazor.Core.Models.Mock
{
    public class MockUpApi : IUpApi
    {
        public const string MockUpToken = "up:demo";

        private readonly UpResponse<PaginatedDataResponse<AccountResource>> _accountsData = new()
        {
            Response = new PaginatedDataResponse<AccountResource>
            {
                Data = new List<AccountResource>
                {
                    new()
                    {
                        Id = "360ef03a-af24-485d-aa9e-bf1249505100",
                        Attributes = new AccountAttributes
                        {
                            AccountType = AccountType.Transactional,
                            DisplayName = "Up Account",
                            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(50)),
                            Balance = new MoneyObject
                            {
                                Value = 100000.ToString(),
                                ValueInBaseUnits = 100000 * 100
                            }
                        }
                    },
                    new()
                    {
                        Id = "2958da0e-7acd-4bd3-a015-6ec8a09f901b",
                        Attributes = new AccountAttributes
                        {
                            AccountType = AccountType.Saver,
                            DisplayName = "🎁 Saver",
                            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(50)),
                            Balance = new MoneyObject
                            {
                                Value = 5000.ToString(),
                                ValueInBaseUnits = 5000 * 100
                            }
                        }
                    },
                    new()
                    {
                        Id = "d452d9e8-437a-4b70-9bb7-2155f6dd87a",
                        Attributes = new AccountAttributes
                        {
                            AccountType = AccountType.Saver,
                            DisplayName = "🌴 Holidays",
                            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(50)),
                            Balance = new MoneyObject
                            {
                                Value = 2000.ToString(),
                                ValueInBaseUnits = 2000 * 100
                            }
                        }
                    }
                }
            }
        };

        public Task<UpResponse<PingResponse>> GetPingAsync() =>
            Task.FromResult(new UpResponse<PingResponse>
            {
                Response = new PingResponse
                {
                    Meta = new PingMeta
                    {
                        Id = Guid.NewGuid().ToString(),
                        StatusEmoji = "⚡ - DEMO"
                    }
                }
            });

        public Task<UpResponse<PaginatedDataResponse<AccountResource>>> GetAccountsAsync(int? pageSize = null) =>
            Task.FromResult(_accountsData);

        public Task<UpResponse<DataResponse<AccountResource>>> GetAccountAsync(string id) => throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<CategoriesResource>>> GetCategoriesAsync(string parentId = null) => throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<CategoriesResource>>> GetCategoryAsync(string id) => throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<TagResource>>> GetTagsAsync(int? pageSize = null) => throw new NotImplementedException();

        public Task<UpResponse<NoResponse>> AddTagsToTransactionAsync(string transactionId, params string[] tagIds) => throw new NotImplementedException();

        public Task<UpResponse<NoResponse>> RemoveTagsFromTransactionAsync(string transactionId, params string[] tagIds) => throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<TransactionResource>>> GetTransactionsAsync(int? pageSize = null, TransactionStatus? status = null, DateTime? since = null,
            DateTime? until = null, string category = null, string tag = null) =>
            throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<TransactionResource>>> GetTransactionsAsync(string accountId, int? pageSize = null, TransactionStatus? status = null,
            DateTime? since = null, DateTime? until = null, string category = null, string tag = null) =>
            throw new NotImplementedException();

        public Task<UpResponse<DataResponse<TransactionResource>>> GetTransactionAsync(string id, int? pageSize = null, TransactionStatus? status = null, DateTime? since = null,
            DateTime? until = null, string category = null, string tag = null) =>
            throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<WebhookResource>>> GetWebhooksAsync(int? pageSize = null) => throw new NotImplementedException();

        public Task<UpResponse<DataResponse<WebhookResource>>> GetWebhooksAsync(string id) => throw new NotImplementedException();

        public Task<UpResponse<DataResponse<WebhookResource>>> CreateWebhookAsync(WebhookInputResource webhook) => throw new NotImplementedException();

        public Task<UpResponse<NoResponse>> DeleteWebhookAsync(string id) => throw new NotImplementedException();

        public Task<UpResponse<WebhookEventResource>> PingWebhookAsync(string webhookId) => throw new NotImplementedException();

        public Task<UpResponse<PaginatedDataResponse<WebhookDeliveryLogResource>>> GetWebhookLogsAsync(string webhookId) => throw new NotImplementedException();
    }
}