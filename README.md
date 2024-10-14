# Laboratorio DotNet

Para correr el proyecto ejecutar

```bash
  docker-compose up --build -d
  docker exec -it mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'Password123' -C -i /docker-entrypoint-initdb.d/init.sql
```