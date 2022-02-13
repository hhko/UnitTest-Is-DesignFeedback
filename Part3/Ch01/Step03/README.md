# Console 컨테이너 디버깅

## 컨테이너 디버깅 확장 도구
- Docker 확장 도구 설치
  - https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker

## 컨테이너 디버깅 설정
- Docker 파일 생성
  - Ctrl + Shift + P : `Docker: Add Docker Files to Workspace...` > `.NET: Core Console` > `Linux` > `No`
    - `Dockerfile` 생성됨
    - `.dockerignore` 파일 추가됨
    - `launch.json` 추가됨
    - `tasks.json` 추가됨
- `tasks.json` OS 설정 변경
  ```json
  {
      "type": "docker-run",
      ... ,
      "dockerRun": {
          "os": "Linux"
      },
      ...
  },
  {
      "type": "docker-run",
      ... ,
      "dockerRun": {
          "os": "Linux"
      },
      ...
  }
  ```

## `Dockerfile` 이해
- [Docker Tools Tips and Tricks](https://code.visualstudio.com/docs/containers/troubleshooting)
  ```dockerfile
  RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
  USER appuser
  ```