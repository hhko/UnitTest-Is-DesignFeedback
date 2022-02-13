
# 호스트 WebAPI 디버깅

```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (web)",
            "launchBrowser": {
                "enabled": true,
                "args": "${auto-detect-url}/swagger",
                "windows": {
                    "command": "cmd.exe",
                    "args": "/C start ${auto-detect-url}/swagger"
                }
            }
        }
```
- 디버깅할 때 WebAPI 테스트를 위한 Swagger 페이지을 연다.
  - `launchBrowser` 설정
  - `cmd /C start https://localhost:7103/swagger/index.html` 명령을 자동 실행 시킨다.