﻿using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");

            builder
                .Property(f => f.ID)
                .HasColumnName("film_id")
                .HasColumnType("int");

            builder
                .Property(f => f.Titulo)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(f => f.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(f => f.Duracao)
                .HasColumnName("length")
                .HasColumnType("smallint");

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .Property<byte>("language_id");

            builder
                .Property<byte?>("original_language_id");

            builder
                .HasOne(f => f.IdiomaFalado)
                .WithMany(i => i.FilmeFalado)
                .HasForeignKey("language_id");

            builder
                .HasOne(f => f.IdiomaOriginal)
                .WithMany(i => i.FilmeOriginal)
                .HasForeignKey("original_language_id");

            builder
                .Property(f => f.TextoClassificacao)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");

            builder
                .Ignore(f => f.Classificacao);
        }
    }
}
