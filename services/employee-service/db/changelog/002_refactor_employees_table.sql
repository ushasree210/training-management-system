-- liquibase formatted sql

-- changeset ukamala:002-refactor-employees

-- 1) Rename column
ALTER TABLE employees RENAME COLUMN name TO first_name;

-- 2) Add new columns
ALTER TABLE employees
  ADD COLUMN last_name  VARCHAR(100) NOT NULL,
  ADD COLUMN email      VARCHAR(255) NOT NULL,
  ADD COLUMN status     VARCHAR(20)  NOT NULL DEFAULT 'Active',
  ADD COLUMN updated_at TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP;

-- 3) Enforce uniqueness
CREATE UNIQUE INDEX ux_employees_email ON employees(email);

-- rollback DROP INDEX IF EXISTS ux_employees_email;
-- rollback ALTER TABLE employees DROP COLUMN IF EXISTS updated_at;
-- rollback ALTER TABLE employees DROP COLUMN IF EXISTS status;
-- rollback ALTER TABLE employees DROP COLUMN IF EXISTS email;
-- rollback ALTER TABLE employees DROP COLUMN IF EXISTS last_name;
-- rollback ALTER TABLE employees RENAME COLUMN first_name TO name;
