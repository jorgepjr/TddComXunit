using CursoTesteXunit.DominioTest.Cursos;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CursoTesteXunit.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string nome = "Asp net core";
        private string descricao = "desenvolvimento de aplicações WEB";
        private double cargaHoraria = 80;
        private PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
        private double valor = 600;


        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            this.descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            this.cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            this.publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            this.valor = valor;
            return this;
        }

        public Curso Build()
        {
            return new Curso(nome, descricao, cargaHoraria, publicoAlvo,valor);
        }
    }
}


