-- liquibase formatted sql

-- changeset ukamala:003-employee-columns-and-index

-- 1) Add missing columns (safe if already exist)
ALTER TABLE employees
    ADD COLUMN IF NOT EXISTS last_name   VARCHAR(100) NOT NULL,
    ADD COLUMN IF NOT EXISTS email       VARCHAR(255) NOT NULL,
    ADD COLUMN IF NOT EXISTS status      VARCHAR(20)  NOT NULL DEFAULT 'Active',
    ADD COLUMN IF NOT EXISTS updated_at  TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP;

-- 2) Enforce uniqueness on email
CREATE UNIQUE INDEX IF NOT EXISTS ux_employees_email
    ON employees(email);

-- rollback
DROP INDEX IF EXISTS ux_employees_email;

ALTER TABLE employees
    DROP COLUMN IF EXISTS updated_at,
    DROP COLUMN IF EXISTS status,
    DROP COLUMN IF EXISTS email,
    DROP COLUMN IF EXISTS last_name;
