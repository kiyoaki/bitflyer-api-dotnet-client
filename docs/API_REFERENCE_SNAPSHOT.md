# bitFlyer Lightning API Reference Snapshot (2025-10-14)

This document captures the canonical endpoint and channel names observed from the official documentation on 2025-10-14 (UTC). When the live documentation diverges from this snapshot, treat the live site as authoritative and refresh these notes.

## REST Endpoints

### Public Endpoints
- `GET /v1/getmarkets`
- `GET /v1/markets`
- `GET /v1/getmarkets/usa`
- `GET /v1/markets/usa`
- `GET /v1/getmarkets/eu`
- `GET /v1/markets/eu`
- `GET /v1/getboard`
- `GET /v1/board`
- `GET /v1/getticker`
- `GET /v1/ticker`
- `GET /v1/getexecutions`
- `GET /v1/executions`
- `GET /v1/getboardstate`
- `GET /v1/gethealth`
- `GET /v1/getfundingrate`
- `GET /v1/getcorporateleverage`
- `GET /v1/getchats`
- `GET /v1/getchats/usa`
- `GET /v1/getchats/eu`

### Private Endpoints
- `GET /v1/me/getpermissions`
- `GET /v1/me/getbalance`
- `GET /v1/me/getcollateral`
- `GET /v1/me/getcollateralaccounts`
- `GET /v1/me/getaddresses`
- `GET /v1/me/getcoinins`
- `GET /v1/me/getcoinouts`
- `GET /v1/me/getbankaccounts`
- `GET /v1/me/getdeposits`
- `POST /v1/me/withdraw`
- `GET /v1/me/getwithdrawals`
- `POST /v1/me/sendchildorder`
- `POST /v1/me/cancelchildorder`
- `POST /v1/me/sendparentorder`
- `POST /v1/me/cancelparentorder`
- `POST /v1/me/cancelallchildorders`
- `GET /v1/me/getchildorders`
- `GET /v1/me/getparentorders`
- `GET /v1/me/getparentorder`
- `GET /v1/me/getexecutions`
- `GET /v1/me/getbalancehistory`
- `GET /v1/me/getpositions`
- `GET /v1/me/getcollateralhistory`
- `GET /v1/me/gettradingcommission`

> **Pending**: The realtime documentation requires client-side rendering, so the websocket channel list could not be captured via static download. Investigate an alternative retrieval method (e.g., ReadMe API export) in a follow-up task.
