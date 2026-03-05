using System;
using System.IO;
using Microsoft.Data.Sqlite;
using AppGreenRoots.Models;

namespace AppGreenRoots.Data;

public static class DatabaseHelper
{
    private static readonly string DbPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "Passaporte_Digital.db");

    private static string ConnectionString => $"Data Source={DbPath}";

    public static Usuario? AutenticarUsuario(string email, string senha)
    {
        using var conn = new SqliteConnection(ConnectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT id_usuario, nome, email, senha
            FROM Usuario
            WHERE email = @email AND senha = @senha
            LIMIT 1";
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@senha", senha);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
            return new Usuario
            {
                Id_Usuario = reader.GetInt32(0),
                Nome       = reader.GetString(1),
                Email      = reader.GetString(2),
                Senha      = reader.GetString(3)
            };
        return null;
    }

    public static bool CadastrarUsuario(string nome, string email, string senha)
    {
        if (senha.Length > 8)
            throw new ArgumentException("A senha deve ter no máximo 8 caracteres.");

        using var conn = new SqliteConnection(ConnectionString);
        conn.Open();

        var check = conn.CreateCommand();
        check.CommandText = "SELECT COUNT(1) FROM Usuario WHERE email = @email";
        check.Parameters.AddWithValue("@email", email);
        if (Convert.ToInt32(check.ExecuteScalar()) > 0) return false;

        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Usuario (nome, email, senha) VALUES (@nome, @email, @senha)";
        cmd.Parameters.AddWithValue("@nome",  nome);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@senha", senha);
        cmd.ExecuteNonQuery();
        return true;
    }
}