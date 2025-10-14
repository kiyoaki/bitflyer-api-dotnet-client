# Plan to update bitFlyer .NET client according to Lightning API docs

## 0. Documentation acquisition and baselining
- [ ] Access the official Lightning REST documentation (https://lightning.bitflyer.com/docs) **and** the realtime API documentation (https://bf-lightning-api.readme.io/docs/realtime-api) on demand when research is required.
  - Direct requests now succeed from this environment:
    - `curl -I https://lightning.bitflyer.com/docs` → HTTP 200 via Envoy proxy.
    - `curl -I https://bf-lightning-api.readme.io/docs/realtime-api` → HTTP 200 with Cloudflare headers.
  - Usage guidelines:
    - Download the relevant pages temporarily during active work sessions (e.g., `curl -L` to a temp directory) and avoid committing the downloaded HTML/asset files to the repository.
    - Capture key details (endpoint descriptions, schema changes, etc.) as curated notes or summaries within project documentation rather than copying the full text of the official docs.
    - Record retrieval metadata (URL, access date, notable response headers) in `docs/SOURCE_NOTES.md` or task-specific notes to provide traceability without storing the raw documentation.
    - Investigate whether bitFlyer publishes downloadable PDFs, an OpenAPI spec, or a GitHub repo mirror that can be tracked for future updates, and document references to those resources instead of mirroring them locally.
  - Ensure contributors understand that the latest authoritative information is always the live documentation, so links should remain in project docs to guide future updates.
- [ ] From the docs, extract the canonical lists of HTTP endpoints, websocket channels (public and private), request/response schemas, and enumerations for later comparison.

## 1. Gap analysis between documentation and current implementation
- [ ] Build a coverage matrix mapping every documented HTTP public endpoint (e.g., `/v1/getticker`, `/v1/getboard`, `/v1/getexecutions`, `/v1/getmarkets`, regional chat endpoints, etc.) to the methods available under `BitFlyer.Apis/PublicApis`. Flag any documented endpoints or query parameters missing in the client (including recent additions such as new market listings, pagination parameters, or throttle information).
- [ ] Perform the same coverage check for private endpoints described under “Private API” in the docs (e.g., `/v1/me/sendchildorder`, `/v1/me/getchildorders`, `/v1/me/getbalance`, `/v1/me/getwithdrawals`, `/v1/me/getpermissions`, `/v1/me/sendcoin`, `/v1/me/withdraw`). Highlight newer endpoints that are currently absent—particularly margin- or staking-related calls that were added after this client was last updated.
- [ ] Review websocket channel documentation (`lightning_board_{product_code}`, `lightning_ticker_{product_code}`, `lightning_executions_{product_code}`, private channels requiring auth, etc.) from the realtime docs and compare with the helper methods available in `RealtimeApi`. Note any authentication requirements or additional channels (e.g., board snapshot or FX-specific feeds) that need new convenience wrappers.
- [ ] Compare documented data models against classes in `ResponseData` and `RequestData`. Capture any new response fields (e.g., additional collateral metrics, event identifiers, settlement prices) or newly required request members so they can be reflected in the data contracts.
- [ ] Review enumerations (`ProductCode`, `CurrencyCode`, `BoardStates`, `BitflyerSystemHealth`, etc.) against the doc’s lists to make sure any new currencies/products/status values are represented.

## 2. Implementation roadmap (post-gap-analysis)
- [ ] Extend `ProductCode` constants and any associated helper methods to include newly documented spot, FX, and altcoin pairs. Ensure they remain in sync with `PublicApi.GetMarkets` by possibly auto-generating or caching the list at runtime instead of using hard-coded values.
- [ ] For each missing public endpoint or query parameter discovered, add wrapper methods to `PublicApi` and corresponding response DTOs. Pay attention to optional filters introduced in the docs (e.g., `before`, `after`, `pagination`, `count`, `message_id`), and ensure method signatures expose them.
- [ ] Implement any missing private endpoints: create request parameter classes (under `RequestData`) and response DTOs, wire them through `PrivateApi`, and update authentication/signature logic if the docs specify changes (such as body hashing rules or timestamp precision).
- [ ] Update existing response classes to include new properties, respecting `DataMember` names from the docs. Where the docs mark fields as optional, use nullable types and default values to maintain backward compatibility.
- [ ] Add higher-level helpers for websocket subscriptions (e.g., strongly-typed wrappers for the documented channel names, reconnect logic if the docs prescribe heartbeat/keepalive handling, and authenticated channels if any new private streams exist).
- [ ] Enhance error handling in `PrivateApi` and `PublicApi` to align with the error payload formats described in the docs, including propagating rate-limit headers or error codes that may have been introduced.
- [ ] Update unit/integration tests in `BitFlyer.Apis.Test` (or add new ones) to cover any new endpoints and data models, possibly using recorded fixtures that mirror the examples provided in the documentation.
- [ ] Refresh developer-facing documentation (`README.md` and samples under `BitFlyer.Sample`) to showcase the new capabilities and note any breaking changes or additional setup (e.g., websocket auth steps).

## 3. Deliverables and verification
- [ ] Document the coverage matrix and summarize deltas in a new `docs/API_Coverage.md` (or similar) file so future maintainers can quickly see alignment with the official docs.
- [ ] Ensure backward compatibility: version the NuGet package appropriately (minor or major bump depending on breaking changes) and communicate deprecations per doc guidance.
- [ ] Perform manual sanity tests against the live API (respecting rate limits and sandbox availability) for at least one endpoint in each category (public, private, websocket) before releasing.
- [ ] Coordinate with stakeholders for review of security-sensitive changes (e.g., handling of API secrets in websocket auth) in case the docs introduced new requirements.
