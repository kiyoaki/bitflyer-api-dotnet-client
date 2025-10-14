# Source Retrieval Notes

## Official Documentation Requests
- **https://lightning.bitflyer.com/docs**
  - Accessed: 2025-10-14 (UTC)
  - Method: `curl -I`
  - Response: HTTP 200 via Envoy; `content-type: text/html; charset=utf-8`; `strict-transport-security: max-age=31536000`.
- **https://bf-lightning-api.readme.io/docs/realtime-api**
  - Accessed: 2025-10-14 (UTC)
  - Method: `curl -I`
  - Response: HTTP 200 via Envoy → Render; Cloudflare `cf-ray: 98e8c3faf98379d9-ORD`; rate limit headers present (`x-ratelimit-limit: 100`).

These endpoints remain the canonical references for REST and realtime channel specifications. Download raw assets on demand only; do not commit them to the repository.
