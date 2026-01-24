-- liquibase formatted sql

-- changeset ukamala:001-create-employees
CREATE TABLE employees (
    id UUID PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    department VARCHAR(100) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- rollback DROP TABLE employees;