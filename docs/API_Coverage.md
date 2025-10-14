# API Coverage Matrix

This document tracks the alignment between the official bitFlyer Lightning API documentation (snapshot 2025-10-14) and the current client implementation.

## Public REST Endpoints

| Endpoint (Docs) | Implemented Method | Coverage Status | Notes |
| --- | --- | --- | --- |
| `GET /v1/getmarkets` / `GET /v1/markets` | `PublicApi.GetMarkets` | ✅ | Client targets `/v1/markets`; docs list both legacy (`getmarkets`) and new path. |
| `GET /v1/getmarkets/usa` / `GET /v1/markets/usa` | `PublicApi.GetMarketsUsa` | ✅ | Same path alias consideration as above. |
| `GET /v1/getmarkets/eu` / `GET /v1/markets/eu` | `PublicApi.GetMarketsEu` | ✅ | — |
| `GET /v1/getboard` / `GET /v1/board` | `PublicApi.GetBoard` | ✅ | — |
| `GET /v1/getticker` / `GET /v1/ticker` | `PublicApi.GetTicker` | ✅ | — |
| `GET /v1/getexecutions` / `GET /v1/executions` | `PublicApi.GetExecutions` | ✅ | Supports `count`, `before`, `after`. |
| `GET /v1/getboardstate` | `PublicApi.GetBoardState` | ✅ | — |
| `GET /v1/gethealth` | `PublicApi.GetHealth` | ⚠️ | Method defaults `product_code` to `BTC_JPY`; docs note optional product code parameter. Verify compatibility. |
| `GET /v1/getfundingrate` | — | ❌ | No wrapper or response DTO exists. |
| `GET /v1/getcorporateleverage` | — | ❌ | No wrapper or response DTO exists. |
| `GET /v1/getchats` | `PublicApi.GetChat` | ✅ | Supports optional `from_date`. |
| `GET /v1/getchats/usa` | `PublicApi.GetChatUsa` | ✅ | Supports optional `from_date`. |
| `GET /v1/getchats/eu` | `PublicApi.GetChatEu` | ✅ | Supports optional `from_date`. |

## Private REST Endpoints

| Endpoint (Docs) | Implemented Method | Coverage Status | Notes |
| --- | --- | --- | --- |
| `GET /v1/me/getpermissions` | `PrivateApi.GetPermissions` | ✅ | Method returns `string[]`. |
| `GET /v1/me/getbalance` | `PrivateApi.GetBalance` | ✅ | — |
| `GET /v1/me/getcollateral` | `PrivateApi.GetCollateral` | ✅ | — |
| `GET /v1/me/getcollateralaccounts` | `PrivateApi.GetCollateralAccounts` | ✅ | — |
| `GET /v1/me/getaddresses` | `PrivateApi.GetAddresses` | ✅ | — |
| `GET /v1/me/getcoinins` | `PrivateApi.GetCoinIns` | ✅ | Supports pagination params. |
| `GET /v1/me/getcoinouts` | `PrivateApi.GetCoinOuts` | ✅ | Supports pagination params. |
| `GET /v1/me/getbankaccounts` | `PrivateApi.GetBankAccounts` | ✅ | — |
| `GET /v1/me/getdeposits` | `PrivateApi.GetDeposits` | ✅ | — |
| `POST /v1/me/withdraw` | `PrivateApi.Withdraw` | ✅ | Returns `WithdrawResult`. |
| `GET /v1/me/getwithdrawals` | `PrivateApi.GetWithdrawals` | ✅ | Supports pagination params. |
| `POST /v1/me/sendchildorder` | `PrivateApi.SendChildOrder` | ✅ | — |
| `POST /v1/me/cancelchildorder` | `PrivateApi.CancelChildOrder` | ✅ | — |
| `POST /v1/me/sendparentorder` | `PrivateApi.SendParentOrder` | ✅ | — |
| `POST /v1/me/cancelparentorder` | `PrivateApi.CancelParentOrder` | ✅ | — |
| `POST /v1/me/cancelallchildorders` | `PrivateApi.CancelAllOrders` | ✅ | — |
| `GET /v1/me/getchildorders` | `PrivateApi.GetChildOrders` / `GetChildOrder` | ✅ | Provides filtering by state, pagination. |
| `GET /v1/me/getparentorders` | `PrivateApi.GetParentOrders` | ✅ | Supports filter parameters. |
| `GET /v1/me/getparentorder` | `PrivateApi.GetParentOrder` | ✅ | — |
| `GET /v1/me/getexecutions` | `PrivateApi.GetExecutions` | ✅ | — |
| `GET /v1/me/getbalancehistory` | `PrivateApi.GetBalanceHistory` | ✅ | Supports pagination & currency filters. |
| `GET /v1/me/getpositions` | `PrivateApi.GetPositions` | ✅ | Accepts product code. |
| `GET /v1/me/getcollateralhistory` | `PrivateApi.GetCollateralHistory` | ✅ | Supports pagination. |
| `GET /v1/me/gettradingcommission` | `PrivateApi.GetTradingCommission` | ✅ | Accepts product code. |
| `POST /v1/me/sendcoin` | `PrivateApi.SendCoin` | ⚠️ | Method exists; docs snapshot lacked entry—confirm latest documentation references this endpoint. |

## Realtime Channels

The ReadMe-hosted realtime documentation relies on client-side rendering. Static retrieval did not expose the channel list; therefore coverage for websocket helpers is **pending manual extraction**. Follow-up action:
1. Investigate ReadMe API export or alternative scrape approach.
2. Compare against `RealtimeApi` helper constants (`RealtimeChannel` enum) once the channel list is available.
