# PostgreSQL 도커 컨테이너

## TODO
- [x] 도커 파일 만들기
- [x] 기본 SQL 실행(/docker-entrypoint-initdb.d 폴더)
- [x] 환경 설정 분리(.env 파일)
  ```
  # --------------------------------------------
  # .env 파일
  # POSTGRES_CONTAINER=postgres
  # POSTGRES_HOST=localhost
  # POSTGRES_PORT=5433
  # POSTGRES_USER=postgres
  # POSTGRES_PASSWORD=password
  # POSTGRES_DBNAME=grafana
  #
  # docker-compose.yml에서 .env 파일 값 참조
  # POSTGRES_HOST: ${POSTGRES_HOST}
  # --------------------------------------------
  ```
- [ ] HealthCheck
- [ ] 데이터 복원을 위한 Volume(/var/lib/postgresql/data)
- [ ] 네트워크