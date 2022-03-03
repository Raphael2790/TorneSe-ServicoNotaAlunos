DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'servnota') THEN
        CREATE SCHEMA servnota;
    END IF;
END $EF$;

CREATE TABLE servnota."Usuarios" (
    "Id" integer GENERATED ALWAYS AS IDENTITY,
    "Nome" VARCHAR(100) NOT NULL,
    "Documento" VARCHAR(11) NOT NULL,
    "DataNascimento" TIMESTAMP(6) NOT NULL,
    "Ativo" BOOLEAN NOT NULL DEFAULT (TRUE),
    "Email" VARCHAR(255) NOT NULL,
    "UsuarioAdm" BOOLEAN NOT NULL DEFAULT (FALSE),
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id")
);


CREATE TABLE servnota."Alunos" (
    "Id" integer NOT NULL,
    "NomeAbreviado" VARCHAR(100) NOT NULL,
    "EmailInterno" VARCHAR(200) NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_Alunos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Alunos_Usuarios_Id" FOREIGN KEY ("Id") REFERENCES servnota."Usuarios" ("Id") ON DELETE CASCADE
);


CREATE TABLE servnota."Professores" (
    "Id" integer NOT NULL,
    "NomeAbreviado" VARCHAR(50) NOT NULL,
    "EmailInterno" VARCHAR(100) NOT NULL,
    "ProfessorTitular" BOOLEAN NOT NULL DEFAULT (TRUE),
    "ProfessorSuplente" BOOLEAN NOT NULL DEFAULT (FALSE),
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "DisciplinaId" integer NOT NULL,
    CONSTRAINT "PK_Professores" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Professores_Usuarios_Id" FOREIGN KEY ("Id") REFERENCES servnota."Usuarios" ("Id") ON DELETE CASCADE
);


CREATE TABLE servnota."Disciplinas" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" VARCHAR(100) NOT NULL,
    "Descricao" VARCHAR(100) NOT NULL,
    "DataInicio" TIMESTAMP(6) NOT NULL,
    "DataFim" TIMESTAMP(6) NOT NULL,
    "TipoDisciplina" text NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "ProfessorId" integer NOT NULL,
    CONSTRAINT "PK_Disciplinas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Disciplinas_Professores_ProfessorId" FOREIGN KEY ("ProfessorId") REFERENCES servnota."Professores" ("Id")
);


CREATE TABLE servnota."Conteudos" (
    "Id" integer GENERATED ALWAYS AS IDENTITY,
    "Nome" VARCHAR(100) NOT NULL,
    "Descricao" VARCHAR(100) NOT NULL,
    "DataInicio" TIMESTAMP(6) NOT NULL,
    "DataTermino" TIMESTAMP(6) NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "DisciplinaId" integer NOT NULL,
    CONSTRAINT "PK_Conteudos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Conteudos_Disciplinas_DisciplinaId" FOREIGN KEY ("DisciplinaId") REFERENCES servnota."Disciplinas" ("Id")
);


CREATE TABLE servnota."Turmas" (
    "Id" integer GENERATED ALWAYS AS IDENTITY,
    "Nome" VARCHAR(50) NOT NULL,
    "Periodo" text NOT NULL,
    "DataInicio" TIMESTAMP(6) NOT NULL,
    "DataFinal" TIMESTAMP(6) NOT NULL,
    "DisciplinaId" integer NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_Turmas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Turmas_Disciplinas_DisciplinaId" FOREIGN KEY ("DisciplinaId") REFERENCES servnota."Disciplinas" ("Id")
);


CREATE TABLE servnota."Atividades" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Descricao" VARCHAR(255) NOT NULL,
    "TipoAtividade" integer NOT NULL,
    "DataAtividade" TIMESTAMP(6) NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "PossuiRetentativa" BOOLEAN NOT NULL DEFAULT (FALSE),
    "ConteudoId" integer NOT NULL,
    CONSTRAINT "PK_Atividades" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Atividades_Conteudos_ConteudoId" FOREIGN KEY ("ConteudoId") REFERENCES servnota."Conteudos" ("Id")
);


CREATE TABLE servnota."AlunosTurmas" (
    "AlunoId" integer NOT NULL,
    "TurmaId" integer NOT NULL,
    "DataCadastro" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_AlunosTurmas" PRIMARY KEY ("AlunoId", "TurmaId"),
    CONSTRAINT "FK_AlunosTurmas_Alunos_AlunoId" FOREIGN KEY ("AlunoId") REFERENCES servnota."Alunos" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AlunosTurmas_Turmas_TurmaId" FOREIGN KEY ("TurmaId") REFERENCES servnota."Turmas" ("Id") ON DELETE CASCADE
);


CREATE TABLE servnota."Notas" (
    "Id" integer GENERATED ALWAYS AS IDENTITY,
    "AlunoId" integer NOT NULL,
    "AtividadeId" integer NOT NULL,
    "ValorNota" double precision NOT NULL,
    "DataLancamento" TIMESTAMP(6) NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "UsuarioId" integer NOT NULL,
    "CanceladaPorRetentativa" BOOLEAN NOT NULL,
    CONSTRAINT "PK_Notas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Notas_Alunos_AlunoId" FOREIGN KEY ("AlunoId") REFERENCES servnota."Alunos" ("Id"),
    CONSTRAINT "FK_Notas_Atividades_AtividadeId" FOREIGN KEY ("AtividadeId") REFERENCES servnota."Atividades" ("Id")
);

INSERT INTO servnota."Usuarios" ("Id", "Ativo", "DataNascimento", "Documento", "Email", "Nome")
OVERRIDING SYSTEM VALUE
VALUES (1234, TRUE, TIMESTAMP '1990-03-10 00:00:00', '87628929919', 'raphael.s@email.com', 'Raphael Silvestre');
INSERT INTO servnota."Usuarios" ("Id", "Ativo", "DataNascimento", "Documento", "Email", "Nome")
OVERRIDING SYSTEM VALUE
VALUES (1282727, TRUE, TIMESTAMP '1983-01-01 00:00:00', '30292919821', 'danilo.aparecido@email.com', 'Danilo Aparecido');


INSERT INTO servnota."Alunos" ("Id", "DataCadastro", "EmailInterno", "NomeAbreviado")
OVERRIDING SYSTEM VALUE
VALUES (1234, TIMESTAMP '2022-03-02 10:42:33.417533', 'raphael.s@email.com', 'Raphael');


INSERT INTO servnota."Professores" ("Id", "DataCadastro", "DisciplinaId", "EmailInterno", "NomeAbreviado", "ProfessorTitular")
OVERRIDING SYSTEM VALUE
VALUES (1282727, TIMESTAMP '2022-03-02 10:42:33.418758', 1341567, 'danilo.s@email.com', 'Danilo', TRUE);


INSERT INTO servnota."Disciplinas" ("Id", "DataCadastro", "DataFim", "DataInicio", "Descricao", "Nome", "ProfessorId", "TipoDisciplina")
VALUES (1341567, TIMESTAMP '2021-09-12 00:00:00', TIMESTAMP '2022-02-12 00:00:00', TIMESTAMP '2021-10-12 00:00:00', 'Matemática base ensino médio', 'Matemática', 1282727, 'Teorica');

INSERT INTO servnota."Conteudos" ("Id", "DataCadastro", "DataInicio", "DataTermino", "Descricao", "DisciplinaId", "Nome")
OVERRIDING SYSTEM VALUE
VALUES (1, TIMESTAMP '2021-10-15 00:00:00', TIMESTAMP '2021-10-18 00:00:00', TIMESTAMP '2021-11-18 00:00:00', 'Aprendizado de equações de segundo grau', 1341567, 'Equações segundo grau');

INSERT INTO servnota."Turmas" ("Id", "DataCadastro", "DataFinal", "DataInicio", "DisciplinaId", "Nome", "Periodo")
OVERRIDING SYSTEM VALUE
VALUES (1, TIMESTAMP '2022-03-02 10:42:33.419047', TIMESTAMP '2021-12-01 00:00:00', TIMESTAMP '2021-06-01 00:00:00', 1341567, 'Grupo Matemática I', 'Noturno');

INSERT INTO servnota."Atividades" ("Id", "ConteudoId", "DataAtividade", "DataCadastro", "Descricao", "TipoAtividade")
VALUES (1, 1, TIMESTAMP '2021-11-10 00:00:00', TIMESTAMP '2021-11-01 00:00:00', 'Atividade avaliativa equações', 1);

INSERT INTO servnota."AlunosTurmas" ("AlunoId", "TurmaId", "DataCadastro")
VALUES (1234, 1, CURRENT_TIMESTAMP);

CREATE INDEX "IX_AlunosTurmas_TurmaId" ON servnota."AlunosTurmas" ("TurmaId");


CREATE INDEX "IX_Atividades_ConteudoId" ON servnota."Atividades" ("ConteudoId");


CREATE INDEX "IX_Conteudos_DisciplinaId" ON servnota."Conteudos" ("DisciplinaId");


CREATE UNIQUE INDEX "IX_Disciplinas_ProfessorId" ON servnota."Disciplinas" ("ProfessorId");


CREATE INDEX "IX_Notas_AlunoId" ON servnota."Notas" ("AlunoId");


CREATE INDEX "IX_Notas_AtividadeId" ON servnota."Notas" ("AtividadeId");


CREATE INDEX "IX_Turmas_DisciplinaId" ON servnota."Turmas" ("DisciplinaId");


