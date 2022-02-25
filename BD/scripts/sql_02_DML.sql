/*USE CAROMETRO
GO*/

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES
	('Administrador'),
	('Aluno'),
	('Professor')
GO
--SELECT * FROM tipoUsuario
--GO

INSERT INTO instituicao(nomeInstituicao, numeroInstituicao, enderecoInstituicao)
VALUES
	('SESI', '081', 'Av. Sen. Roberto Símonsen, 550 - Jardim Imperador, Suzano - SP, 08673-270')
GO
--SELECT * FROM instituicao
--GO

INSERT INTO usuario(idInstituicao, idTipoUsuario, nomeUsuario, rg, email, senha, imagem)
VALUES
	('1','1', 'admteste', '12.345.678-9', 'adm@email.com', 'adm123', ''),
	('1', '2', 'alunoteste', '23.456.789-0', 'aluno@email.com', 'aluno123', ''),
	('1', '3', 'professorteste', '34.567.890-1', 'professor@email.com', 'professor123', '')
GO
--SELECT * FROM usuario
--GO

INSERT INTO professor(idUsuario, matricula)
VALUES
	('3', '1234')
GO
--SELECT * FROM professor
--GO

INSERT INTO periodo(nomePeriodo)
VALUES
	('Manhã'),
	('Tarde')
GO
--SELECT * FROM periodo
--GO

INSERT INTO turma(idPeriodo, nomeTurma)
VALUES
	('1', '3°Ano'),
	('2', '3°Ano')
GO
--SELECT * FROM turma
--GO

INSERT INTO aluno(idTurma, idUsuario, matricula)
VALUES
	('1', '2', '112233')
GO
--SELECT * FROM aluno
--GO

INSERT INTO cracha(idUsuario, token)
VALUES
	('2', '11223344556677889900')
GO
--SELECT * FROM cracha
--GO
