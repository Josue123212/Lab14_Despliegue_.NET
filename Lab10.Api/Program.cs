using Lab10.Api.Configuration;
using Lab10.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Cargar servicios inyectados
builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

// Inicializar tablas en Neon automáticamente si no existen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.ExecuteSqlRawAsync(@"
        CREATE EXTENSION IF NOT EXISTS ""uuid-ossp"";

        CREATE TABLE IF NOT EXISTS roles (
            role_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
            role_name VARCHAR(50) NOT NULL UNIQUE
        );

        CREATE TABLE IF NOT EXISTS users (
            user_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
            username VARCHAR(100) NOT NULL UNIQUE,
            password_hash VARCHAR(255) NOT NULL,
            email VARCHAR(150) NOT NULL UNIQUE,
            created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
        );

        CREATE TABLE IF NOT EXISTS user_roles (
            user_id UUID NOT NULL,
            role_id UUID NOT NULL,
            assigned_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
            CONSTRAINT user_roles_pkey PRIMARY KEY (user_id, role_id),
            CONSTRAINT user_roles_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
            CONSTRAINT user_roles_role_id_fkey FOREIGN KEY (role_id) REFERENCES roles(role_id) ON DELETE CASCADE
        );

        CREATE TABLE IF NOT EXISTS tickets (
            ticket_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
            user_id UUID NOT NULL,
            title VARCHAR(255) NOT NULL,
            description TEXT,
            status VARCHAR(20) NOT NULL,
            created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
            closed_at TIMESTAMP WITHOUT TIME ZONE,
            CONSTRAINT tickets_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(user_id)
        );

        CREATE TABLE IF NOT EXISTS responses (
            response_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
            ticket_id UUID NOT NULL,
            responder_id UUID NOT NULL,
            message TEXT NOT NULL,
            created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
            CONSTRAINT responses_ticket_id_fkey FOREIGN KEY (ticket_id) REFERENCES tickets(ticket_id) ON DELETE CASCADE,
            CONSTRAINT responses_responder_id_fkey FOREIGN KEY (responder_id) REFERENCES users(user_id)
        );

        INSERT INTO roles (role_name) VALUES ('Administrador'), ('Soporte'), ('Cliente') ON CONFLICT (role_name) DO NOTHING;
        INSERT INTO users (username, password_hash, email) VALUES ('josue.choquepuma', 'hash_demo_123', 'josue.choquepuma@tecsup.edu.pe') ON CONFLICT (username) DO NOTHING;
    ");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();