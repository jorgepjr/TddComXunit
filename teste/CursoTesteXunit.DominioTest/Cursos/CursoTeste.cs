using CursoTesteXunit.DominioTest._Util;
using ExpectedObjects;
using System;
using CursoTesteXunit.DominioTest._Builders;
using Xunit;
using Xunit.Abstractions;

namespace CursoTesteXunit.DominioTest.Cursos
{
    //"Eu enquanto administrador, quero criar e editar cursos para que sejam abertas matrículas para o mesmo."

    // Criterios de aceite
    //- Criar cursos com: nome, carga horaria, publico alvo e valor do curso
    //- As opções para o publico alvo são: Estudante, Universitário, Empregado e Empregador.
    //- Todos os campos do curso sao obrigatorios.

    public class CursoTeste : IDisposable
    {
        private readonly ITestOutputHelper testOutput;
        private readonly string nome;
        private readonly string descricao;
        private readonly double cargaHoraria;
        private readonly PublicoAlvo publicoAlvo;
        private readonly double valor;

        public CursoTeste(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;

            nome = "Asp net core";
            cargaHoraria = 80;
            publicoAlvo = PublicoAlvo.Estudante;
            valor = 600;
        }

        public void Dispose()
        {
            testOutput.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = nome,
                Descricao = descricao,
                CargaHoraria = cargaHoraria,
                PublicoAlvo = publicoAlvo,
                Valor = valor
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeDoCursoNaoPodeSerInvalido(string nomeInvalido)
        {

            Assert.Throws<ArgumentException>(()
               => CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                  .ComMensagem("Nome inválido!");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-3)]
        public void CargaHorariaNaoDeveSerMenorQueUm(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(()
               => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
               .ComMensagem("Carga horaria inválida!");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-200)]
        public void ValorNaoDeveSerMenorQueUm(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(()
                => CursoBuilder.Novo().ComValor(valorInvalido).Build())
                 .ComMensagem("Valor inválido!");

        }

      
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empregador
    }
    public class Curso
    {

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome inválido!");
            }

            if (cargaHoraria < 1)
            {
                throw new ArgumentException("Carga horaria inválida!");
            }

            if (valor < 1)
            {
                throw new ArgumentException("Valor inválido!");
            }

        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }


    }
}

