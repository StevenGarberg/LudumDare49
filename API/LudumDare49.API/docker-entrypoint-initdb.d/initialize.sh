#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER api;
    CREATE DATABASE ludumdare49;
    GRANT ALL PRIVILEGES ON DATABASE ludumdare49 TO api;
EOSQL