using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Theatre.BD_Context;

public partial class PostgresContext : DbContext
{
    private static PostgresContext instance;
    public static PostgresContext Instance => instance ?? (instance = new PostgresContext());
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AverageTermUse> AverageTermUses { get; set; }

    public virtual DbSet<InfoActorsRole> InfoActorsRoles { get; set; }

    public virtual DbSet<InfoActorsUnderstudy> InfoActorsUnderstudies { get; set; }

    public virtual DbSet<PолиБд> PолиБдs { get; set; }

    public virtual DbSet<RolesCount> RolesCounts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Абонементы> Абонементыs { get; set; }

    public virtual DbSet<Актеры> Актерыs { get; set; }

    public virtual DbSet<Билеты> Билетыs { get; set; }

    public virtual DbSet<ВыданныеЗвания> ВыданныеЗванияs { get; set; }

    public virtual DbSet<Договоры> Договорыs { get; set; }

    public virtual DbSet<Должности> Должностиs { get; set; }

    public virtual DbSet<Дублеры> Дублерыs { get; set; }

    public virtual DbSet<ЖанрыПостановок> ЖанрыПостановокs { get; set; }

    public virtual DbSet<Звания> Званияs { get; set; }

    public virtual DbSet<Инвентарь> Инвентарьs { get; set; }

    public virtual DbSet<Клиенты> Клиентыs { get; set; }

    public virtual DbSet<Костюмы> Костюмыs { get; set; }

    public virtual DbSet<Места> Местаs { get; set; }

    public virtual DbSet<Пол> Полs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Поставщики> Поставщикиs { get; set; }

    public virtual DbSet<Расписание> Расписаниеs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<РолиАктеров> РолиАктеровs { get; set; }

    public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }

    public virtual DbSet<Спектакли> Спектаклиs { get; set; }

    public virtual DbSet<ТипИнвентаря> ТипИнвентаряs { get; set; }

    public virtual DbSet<ТипКостюма> ТипКостюмаs { get; set; }

    public virtual DbSet<ТипыАбонементов> ТипыАбонементовs { get; set; }

    public virtual DbSet<ТипыМест> ТипыМестs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=tyuKo467");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<AverageTermUse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("average_term_use");

            entity.Property(e => e.Avg).HasColumnName("avg");
            entity.Property(e => e.НаименованиеТипа)
                .HasMaxLength(45)
                .HasColumnName("Наименование_типа");
        });

        modelBuilder.Entity<InfoActorsRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("info_actors_roles");

            entity.Property(e => e.Актер).HasColumnName("актер");
            entity.Property(e => e.Роль).HasColumnName("роль");
            entity.Property(e => e.Спектакль).HasColumnName("спектакль");
        });

        modelBuilder.Entity<InfoActorsUnderstudy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("info_actors_understudy");

            entity.Property(e => e.Актер).HasColumnName("актер");
            entity.Property(e => e.Дублер).HasColumnName("дублер");
        });

        modelBuilder.Entity<PолиБд>(entity =>
        {
            entity.HasKey(e => e.Idроли).HasName("pоли_pk");

            entity.ToTable("pоли_бд");

            entity.Property(e => e.Idроли)
                .HasDefaultValueSql("nextval('\"pоли_idроли_seq\"'::regclass)")
                .HasColumnName("idроли");
            entity.Property(e => e.НаименованиеРоли)
                .HasColumnType("character varying")
                .HasColumnName("наименование_роли");
        });

        modelBuilder.Entity<RolesCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("roles_count");

            entity.Property(e => e.RolesCount1).HasColumnName("roles_count");
            entity.Property(e => e.Имя).HasMaxLength(45);
            entity.Property(e => e.Отчество).HasMaxLength(45);
            entity.Property(e => e.Фамилия).HasMaxLength(45);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales");

            entity.Property(e => e.ДатаПродаж).HasColumnName("Дата_продаж");
            entity.Property(e => e.СуммаПродаж).HasColumnName("Сумма_продаж");
        });

        modelBuilder.Entity<Абонементы>(entity =>
        {
            entity.HasKey(e => e.IdАбонемента).HasName("абонементы_pkey1");

            entity.ToTable("абонементы");

            entity.Property(e => e.IdАбонемента).HasColumnName("idАбонемента");
            entity.Property(e => e.ДатаНачала).HasColumnName("Дата_начала");
            entity.Property(e => e.ДатаОкончания).HasColumnName("Дата_окончания");
            entity.Property(e => e.КодКлиента).HasColumnName("Код_клиента");
            entity.Property(e => e.КодТипа).HasColumnName("Код_типа");
            entity.Property(e => e.Стоимость).HasPrecision(6, 2);

            entity.HasOne(d => d.КодКлиентаNavigation).WithMany(p => p.Абонементыs)
                .HasForeignKey(d => d.КодКлиента)
                .HasConstraintName("Клиенты_абонементы_ключ");

            entity.HasOne(d => d.КодТипаNavigation).WithMany(p => p.Абонементыs)
                .HasForeignKey(d => d.КодТипа)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Типы_абонементы_ключ");
        });

        modelBuilder.Entity<Актеры>(entity =>
        {
            entity.HasKey(e => e.IdАктера).HasName("актеры_pkey");

            entity.ToTable("актеры");

            entity.Property(e => e.IdАктера).HasColumnName("idАктера");
            entity.Property(e => e.ВнешниеОсобенности).HasColumnName("Внешние_особенности");
            entity.Property(e => e.КодСотрудника).HasColumnName("Код_сотрудника");
            entity.Property(e => e.Пол).HasMaxLength(1);
            entity.Property(e => e.Фото).HasColumnName("фото");

            entity.HasOne(d => d.КодСотрудникаNavigation).WithMany(p => p.Актерыs)
                .HasForeignKey(d => d.КодСотрудника)
                .HasConstraintName("Сотрудники_Актеры_Ключ");

            entity.HasOne(d => d.ПолNavigation).WithMany(p => p.Актерыs)
                .HasPrincipalKey(p => p.КодПола)
                .HasForeignKey(d => d.Пол)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Пол_Актеры_ключ");

            entity.HasMany(d => d.КодДублераs).WithMany(p => p.КодАктераs)
                .UsingEntity<Dictionary<string, object>>(
                    "АктерыДублеры",
                    r => r.HasOne<Дублеры>().WithMany()
                        .HasForeignKey("КодДублера")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Дублеры_Смеж_ключ"),
                    l => l.HasOne<Актеры>().WithMany()
                        .HasForeignKey("КодАктера")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Актеры_Смеж_Ключ"),
                    j =>
                    {
                        j.HasKey("КодАктера", "КодДублера").HasName("актеры_дублеры_pkey");
                        j.ToTable("актеры_дублеры");
                        j.IndexerProperty<int>("КодАктера").HasColumnName("код_актера");
                        j.IndexerProperty<int>("КодДублера").HasColumnName("код_дублера");
                    });
        });

        modelBuilder.Entity<Билеты>(entity =>
        {
            entity.HasKey(e => e.IdБилета).HasName("билеты_pkey");

            entity.ToTable("билеты");

            entity.Property(e => e.IdБилета).HasColumnName("idБилета");
            entity.Property(e => e.КодМеста).HasColumnName("Код_места");
            entity.Property(e => e.КодПользователя).HasColumnName("код_пользователя");
            entity.Property(e => e.КодРасписания).HasColumnName("Код_расписания");
            entity.Property(e => e.Стоимость).HasPrecision(6, 2);

            entity.HasOne(d => d.КодМестаNavigation).WithMany(p => p.Билетыs)
                .HasForeignKey(d => d.КодМеста)
                .HasConstraintName("Места_Билеты_Ключ");

            entity.HasOne(d => d.КодПользователяNavigation).WithMany(p => p.Билетыs)
                .HasForeignKey(d => d.КодПользователя)
                .HasConstraintName("билеты_fk");

            entity.HasOne(d => d.КодРасписанияNavigation).WithMany(p => p.Билетыs)
                .HasForeignKey(d => d.КодРасписания)
                .HasConstraintName("Расписание_Билеты_Ключ");
        });

        modelBuilder.Entity<ВыданныеЗвания>(entity =>
        {
            entity.HasKey(e => e.IdВыданногоЗвания).HasName("выданные_звания_pkey");

            entity.ToTable("выданные_звания");

            entity.Property(e => e.IdВыданногоЗвания)
                .HasDefaultValueSql("nextval('\"выданные_звания_idВыданного_зван_seq\"'::regclass)")
                .HasColumnName("idВыданного_звания");
            entity.Property(e => e.ДатаВыдачи).HasColumnName("Дата_выдачи");
            entity.Property(e => e.КодАктера).HasColumnName("Код_актера");
            entity.Property(e => e.КодЗвания).HasColumnName("Код_звания");

            entity.HasOne(d => d.КодАктераNavigation).WithMany(p => p.ВыданныеЗванияs)
                .HasForeignKey(d => d.КодАктера)
                .HasConstraintName("Актеры_выдача_ключ");

            entity.HasOne(d => d.КодЗванияNavigation).WithMany(p => p.ВыданныеЗванияs)
                .HasForeignKey(d => d.КодЗвания)
                .HasConstraintName("Звания_выдача_ключ");
        });

        modelBuilder.Entity<Договоры>(entity =>
        {
            entity.HasKey(e => e.IdДоговора).HasName("договоры_pkey");

            entity.ToTable("договоры");

            entity.Property(e => e.IdДоговора).HasColumnName("idДоговора");
            entity.Property(e => e.ДатаЗаключенияДоговора).HasColumnName("Дата_заключения_договора");
            entity.Property(e => e.ДопУсловияДоговора).HasColumnName("Доп_Условия_договора");
            entity.Property(e => e.КодПоставщика).HasColumnName("Код_поставщика");

            entity.HasOne(d => d.КодПоставщикаNavigation).WithMany(p => p.Договорыs)
                .HasForeignKey(d => d.КодПоставщика)
                .HasConstraintName("Поставщики_Договоры");
        });

        modelBuilder.Entity<Должности>(entity =>
        {
            entity.HasKey(e => e.IdДолжности).HasName("должности_pkey");

            entity.ToTable("должности");

            entity.Property(e => e.IdДолжности).HasColumnName("idДолжности");
            entity.Property(e => e.Зарплата).HasPrecision(8, 2);
            entity.Property(e => e.НаименованиеДолжности)
                .HasMaxLength(45)
                .HasColumnName("Наименование_должности");
        });

        modelBuilder.Entity<Дублеры>(entity =>
        {
            entity.HasKey(e => e.IdДублера).HasName("дублеры_pkey");

            entity.ToTable("дублеры");

            entity.Property(e => e.IdДублера).HasColumnName("idДублера");
            entity.Property(e => e.ВнешниеОсобенности).HasColumnName("Внешние_особенности");
            entity.Property(e => e.КодСотрудника).HasColumnName("Код_сотрудника");
            entity.Property(e => e.Пол).HasMaxLength(1);

            entity.HasOne(d => d.КодСотрудникаNavigation).WithMany(p => p.Дублерыs)
                .HasForeignKey(d => d.КодСотрудника)
                .HasConstraintName("Сотрудники_Дублеры_ключ");

            entity.HasOne(d => d.ПолNavigation).WithMany(p => p.Дублерыs)
                .HasPrincipalKey(p => p.КодПола)
                .HasForeignKey(d => d.Пол)
                .HasConstraintName("Дублеры_Пол_Ключ");
        });

        modelBuilder.Entity<ЖанрыПостановок>(entity =>
        {
            entity.HasKey(e => e.IdЖанра).HasName("жанры_постановок_pkey");

            entity.ToTable("жанры_постановок");

            entity.Property(e => e.IdЖанра).HasColumnName("idЖанра");
            entity.Property(e => e.НаименованиеЖанра)
                .HasMaxLength(45)
                .HasColumnName("Наименование_жанра");
            entity.Property(e => e.ОписаниеЖанра).HasColumnName("Описание_жанра");
        });

        modelBuilder.Entity<Звания>(entity =>
        {
            entity.HasKey(e => e.IdЗвания).HasName("звания_pkey");

            entity.ToTable("звания");

            entity.Property(e => e.IdЗвания).HasColumnName("idЗвания");
            entity.Property(e => e.НаименованиеЗвания)
                .HasMaxLength(45)
                .HasColumnName("Наименование_звания");
            entity.Property(e => e.УсловияПолучения).HasColumnName("Условия_получения");
        });

        modelBuilder.Entity<Инвентарь>(entity =>
        {
            entity.HasKey(e => e.IdИнвентаря).HasName("инвентарь_pkey");

            entity.ToTable("инвентарь");

            entity.Property(e => e.IdИнвентаря).HasColumnName("idИнвентаря");
            entity.Property(e => e.ДатаНачалаИспользования).HasColumnName("Дата_начала_использования");
            entity.Property(e => e.ДатаСписания).HasColumnName("Дата_списания");
            entity.Property(e => e.КодТипа).HasColumnName("Код_типа");
            entity.Property(e => e.НазваниеИнвентаря)
                .HasMaxLength(45)
                .HasColumnName("Название_инвентаря");
            entity.Property(e => e.СрокИспользования).HasColumnName("Срок_использования");
            entity.Property(e => e.Стоимость)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("NULL::numeric");

            entity.HasOne(d => d.КодТипаNavigation).WithMany(p => p.Инвентарьs)
                .HasForeignKey(d => d.КодТипа)
                .HasConstraintName("Тип_инвентарь_ключ");

            entity.HasMany(d => d.КодСпектакляs).WithMany(p => p.КодИнвентаряs)
                .UsingEntity<Dictionary<string, object>>(
                    "ИнвентарьДляСпектакля",
                    r => r.HasOne<Спектакли>().WithMany()
                        .HasForeignKey("КодСпектакля")
                        .HasConstraintName("Спектакль_Инвентарь_Ключ"),
                    l => l.HasOne<Инвентарь>().WithMany()
                        .HasForeignKey("КодИнвентаря")
                        .HasConstraintName("Инвентарь_Спектакль_Ключ"),
                    j =>
                    {
                        j.HasKey("КодИнвентаря", "КодСпектакля").HasName("инвентарь_для_спектакля_pkey");
                        j.ToTable("инвентарь_для_спектакля");
                        j.IndexerProperty<int>("КодИнвентаря").HasColumnName("Код_инвентаря");
                        j.IndexerProperty<int>("КодСпектакля").HasColumnName("Код_спектакля");
                    });
        });

        modelBuilder.Entity<Клиенты>(entity =>
        {
            entity.HasKey(e => e.IdКлиента).HasName("клиенты_pkey");

            entity.ToTable("клиенты");

            entity.Property(e => e.IdКлиента).HasColumnName("idКлиента");
            entity.Property(e => e.НомерПаспорта).HasColumnName("Номер_паспорта");
            entity.Property(e => e.СерияПаспорта).HasColumnName("Серия_паспорта");
        });

        modelBuilder.Entity<Костюмы>(entity =>
        {
            entity.HasKey(e => e.IdКостюма).HasName("костюмы_pkey");

            entity.ToTable("костюмы");

            entity.Property(e => e.IdКостюма).HasColumnName("idКостюма");
            entity.Property(e => e.ДатаНачалаИспользования).HasColumnName("Дата_начала_использования");
            entity.Property(e => e.ДатаСписания).HasColumnName("Дата_списания");
            entity.Property(e => e.КодДоговора).HasColumnName("Код_договора");
            entity.Property(e => e.КодТипа).HasColumnName("Код_типа");
            entity.Property(e => e.НазваниеКостюма)
                .HasMaxLength(45)
                .HasColumnName("Название_костюма");
            entity.Property(e => e.Стоимость)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("NULL::numeric");

            entity.HasOne(d => d.КодДоговораNavigation).WithMany(p => p.Костюмыs)
                .HasForeignKey(d => d.КодДоговора)
                .HasConstraintName("Договоры_Костюмы_Ключ");

            entity.HasOne(d => d.КодТипаNavigation).WithMany(p => p.Костюмыs)
                .HasForeignKey(d => d.КодТипа)
                .HasConstraintName("Типы_костюмы_ключ");

            entity.HasMany(d => d.КодСпектакляs).WithMany(p => p.КодКостюмаs)
                .UsingEntity<Dictionary<string, object>>(
                    "КостюмыДляСпектаклей",
                    r => r.HasOne<Спектакли>().WithMany()
                        .HasForeignKey("КодСпектакля")
                        .HasConstraintName("Спектакли_Костюмы_Ключ"),
                    l => l.HasOne<Костюмы>().WithMany()
                        .HasForeignKey("КодКостюма")
                        .HasConstraintName("Костюмы_Спектакли_Ключ"),
                    j =>
                    {
                        j.HasKey("КодКостюма", "КодСпектакля").HasName("костюмы_для_спектаклей_pkey");
                        j.ToTable("костюмы_для_спектаклей");
                        j.IndexerProperty<int>("КодКостюма").HasColumnName("Код_костюма");
                        j.IndexerProperty<int>("КодСпектакля").HasColumnName("Код_спектакля");
                    });
        });

        modelBuilder.Entity<Места>(entity =>
        {
            entity.HasKey(e => e.IdМеста).HasName("места_pkey");

            entity.ToTable("места");

            entity.Property(e => e.IdМеста).HasColumnName("idМеста");
            entity.Property(e => e.КодТипаМеста).HasColumnName("Код_типа_места");
            entity.Property(e => e.НомерМеста).HasColumnName("Номер_места");

            entity.HasOne(d => d.КодТипаМестаNavigation).WithMany(p => p.Местаs)
                .HasForeignKey(d => d.КодТипаМеста)
                .HasConstraintName("Места_ТипыМест_Ключ");
        });

        modelBuilder.Entity<Пол>(entity =>
        {
            entity.HasKey(e => e.IdПол).HasName("пол_pkey");

            entity.ToTable("пол");

            entity.HasIndex(e => e.КодПола, "пол_код_пола_key").IsUnique();

            entity.Property(e => e.IdПол).HasColumnName("idПол");
            entity.Property(e => e.КодПола)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("код_пола");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.Idпользователя).HasName("пользователи_pk");

            entity.ToTable("пользователи");

            entity.Property(e => e.Idпользователя).HasColumnName("idпользователя");
            entity.Property(e => e.КодРоли).HasColumnName("код_роли");
            entity.Property(e => e.Логин)
                .HasColumnType("character varying")
                .HasColumnName("логин");
            entity.Property(e => e.Пароль)
                .HasColumnType("character varying")
                .HasColumnName("пароль");
            entity.Property(e => e.Почта)
                .HasColumnType("character varying")
                .HasColumnName("почта");
            entity.Property(e => e.Соль).HasColumnName("соль");

            entity.HasOne(d => d.КодРолиNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.КодРоли)
                .HasConstraintName("пользователи_fk");
        });

        modelBuilder.Entity<Поставщики>(entity =>
        {
            entity.HasKey(e => e.IdПоставщика).HasName("поставщики_pkey");

            entity.ToTable("поставщики");

            entity.Property(e => e.IdПоставщика).HasColumnName("idПоставщика");
            entity.Property(e => e.Адрес)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.ИмяПоставщика)
                .HasMaxLength(45)
                .HasColumnName("Имя_поставщика");
            entity.Property(e => e.Телефон)
                .HasMaxLength(12)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength();
        });

        modelBuilder.Entity<Расписание>(entity =>
        {
            entity.HasKey(e => e.IdРасписания).HasName("расписание_pkey");

            entity.ToTable("расписание");

            entity.Property(e => e.IdРасписания).HasColumnName("idРасписания");
            entity.Property(e => e.ВремяНачала).HasColumnName("Время_начала");
            entity.Property(e => e.ДатаНачала).HasColumnName("Дата_начала");
            entity.Property(e => e.КодСпектакля).HasColumnName("Код_спектакля");

            entity.HasOne(d => d.КодСпектакляNavigation).WithMany(p => p.Расписаниеs)
                .HasForeignKey(d => d.КодСпектакля)
                .HasConstraintName("Спектакли_Расписание_Ключ");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.IdРоли).HasName("роли_pkey");

            entity.ToTable("роли");

            entity.Property(e => e.IdРоли).HasColumnName("idРоли");
            entity.Property(e => e.ДопИнформация).HasColumnName("Доп_информация");
            entity.Property(e => e.НазваниеРоли).HasColumnName("Название_роли");
        });

        modelBuilder.Entity<РолиАктеров>(entity =>
        {
            entity.HasKey(e => new { e.КодРоли, e.КодАктера }).HasName("роли_актеров_pkey");

            entity.ToTable("роли_актеров");

            entity.Property(e => e.КодРоли).HasColumnName("Код_Роли");
            entity.Property(e => e.КодАктера).HasColumnName("Код_актера");
            entity.Property(e => e.ДатаНазначенияНаРоль).HasColumnName("Дата_назначения_на_роль");
            entity.Property(e => e.ДатаСнятияСРоли).HasColumnName("Дата_снятия_с_роли");

            entity.HasOne(d => d.КодАктераNavigation).WithMany(p => p.РолиАктеровs)
                .HasForeignKey(d => d.КодАктера)
                .HasConstraintName("Актеры_Роли_Ключ");

            entity.HasOne(d => d.КодРолиNavigation).WithMany(p => p.РолиАктеровs)
                .HasForeignKey(d => d.КодРоли)
                .HasConstraintName("Роли_Актеры_Ключ");
        });

        modelBuilder.Entity<Сотрудники>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника).HasName("сотрудники_pkey");

            entity.ToTable("сотрудники");

            entity.Property(e => e.IdСотрудника).HasColumnName("idСотрудника");
            entity.Property(e => e.Имя).HasMaxLength(45);
            entity.Property(e => e.КемВыдан).HasColumnName("Кем_выдан");
            entity.Property(e => e.КодДолжности).HasColumnName("Код_должности");
            entity.Property(e => e.НомерПаспорта)
                .HasMaxLength(6)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength()
                .HasColumnName("Номер_паспорта");
            entity.Property(e => e.Отчество)
                .HasMaxLength(45)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.СерияПаспорта)
                .HasMaxLength(4)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength()
                .HasColumnName("Серия_паспорта");
            entity.Property(e => e.Телефон)
                .HasMaxLength(12)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength();
            entity.Property(e => e.Фамилия).HasMaxLength(45);

            entity.HasOne(d => d.КодДолжностиNavigation).WithMany(p => p.Сотрудникиs)
                .HasForeignKey(d => d.КодДолжности)
                .HasConstraintName("Должности_Сотрудники_Ключ");
        });

        modelBuilder.Entity<Спектакли>(entity =>
        {
            entity.HasKey(e => e.IdСпектакля).HasName("спектакли_pkey");

            entity.ToTable("спектакли");

            entity.Property(e => e.IdСпектакля).HasColumnName("idСпектакля");
            entity.Property(e => e.Бюджет)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("NULL::numeric");
            entity.Property(e => e.КодЖанраСпектакля).HasColumnName("Код_жанра_спектакля");
            entity.Property(e => e.НазваниеСпектакля).HasColumnName("Название_спектакля");
            entity.Property(e => e.Фото)
                .HasMaxLength(255)
                .HasColumnName("фото");

            entity.HasOne(d => d.КодЖанраСпектакляNavigation).WithMany(p => p.Спектаклиs)
                .HasForeignKey(d => d.КодЖанраСпектакля)
                .HasConstraintName("Жанры_Спектакли_Ключ");

            entity.HasMany(d => d.КодАбонементаs).WithMany(p => p.КодСпектакляs)
                .UsingEntity<Dictionary<string, object>>(
                    "СпектаклиАбонементы",
                    r => r.HasOne<Абонементы>().WithMany()
                        .HasForeignKey("КодАбонемента")
                        .HasConstraintName("Абонементы_смеж_ключ"),
                    l => l.HasOne<Спектакли>().WithMany()
                        .HasForeignKey("КодСпектакля")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Спектакли_смеж_ключ"),
                    j =>
                    {
                        j.HasKey("КодСпектакля", "КодАбонемента").HasName("спектакли_абонементы_pkey");
                        j.ToTable("спектакли_абонементы");
                        j.IndexerProperty<int>("КодСпектакля").HasColumnName("Код_спектакля");
                        j.IndexerProperty<int>("КодАбонемента").HasColumnName("Код_абонемента");
                    });

            entity.HasMany(d => d.КодРолиs).WithMany(p => p.КодСпектакляs)
                .UsingEntity<Dictionary<string, object>>(
                    "РолиВСпектаклях",
                    r => r.HasOne<Роли>().WithMany()
                        .HasForeignKey("КодРоли")
                        .HasConstraintName("Роли_Спектаки_Ключ"),
                    l => l.HasOne<Спектакли>().WithMany()
                        .HasForeignKey("КодСпектакля")
                        .HasConstraintName("Спектакли_Роли_Ключ"),
                    j =>
                    {
                        j.HasKey("КодСпектакля", "КодРоли").HasName("роли_в_спектаклях_pkey");
                        j.ToTable("роли_в_спектаклях");
                        j.IndexerProperty<int>("КодСпектакля").HasColumnName("Код_спектакля");
                        j.IndexerProperty<int>("КодРоли").HasColumnName("Код_роли");
                    });

            entity.HasMany(d => d.КодСотрудникаs).WithMany(p => p.КодСпектакляs)
                .UsingEntity<Dictionary<string, object>>(
                    "СотрудникиСпектакля",
                    r => r.HasOne<Сотрудники>().WithMany()
                        .HasForeignKey("КодСотрудника")
                        .HasConstraintName("Сотрудники_Спектакли_Ключ"),
                    l => l.HasOne<Спектакли>().WithMany()
                        .HasForeignKey("КодСпектакля")
                        .HasConstraintName("Спектакли_Сотрудники_Ключ"),
                    j =>
                    {
                        j.HasKey("КодСпектакля", "КодСотрудника").HasName("сотрудники_спектакля_pkey");
                        j.ToTable("сотрудники_спектакля");
                        j.IndexerProperty<int>("КодСпектакля").HasColumnName("Код_Спектакля");
                        j.IndexerProperty<int>("КодСотрудника").HasColumnName("Код_Сотрудника");
                    });
        });

        modelBuilder.Entity<ТипИнвентаря>(entity =>
        {
            entity.HasKey(e => e.IdТипа).HasName("тип_инвентаря_pkey");

            entity.ToTable("тип_инвентаря");

            entity.Property(e => e.IdТипа).HasColumnName("idТипа");
            entity.Property(e => e.НаименованиеТипа)
                .HasMaxLength(45)
                .HasColumnName("Наименование_типа");
            entity.Property(e => e.ОписаниеТипа).HasColumnName("Описание_типа");
        });

        modelBuilder.Entity<ТипКостюма>(entity =>
        {
            entity.HasKey(e => e.IdТипа).HasName("тип_костюма_pkey");

            entity.ToTable("тип_костюма");

            entity.Property(e => e.IdТипа).HasColumnName("idТипа");
            entity.Property(e => e.НазваниеТипа).HasColumnName("Название_типа");
        });

        modelBuilder.Entity<ТипыАбонементов>(entity =>
        {
            entity.HasKey(e => e.IdТипа).HasName("абонементы_pkey");

            entity.ToTable("типы_абонементов");

            entity.Property(e => e.IdТипа)
                .HasDefaultValueSql("nextval('\"абонементы_idТипа_seq\"'::regclass)")
                .HasColumnName("idТипа");
            entity.Property(e => e.НазваниеТипа).HasColumnName("Название_типа");
            entity.Property(e => e.ОписаниеТипа).HasColumnName("Описание_типа");
        });

        modelBuilder.Entity<ТипыМест>(entity =>
        {
            entity.HasKey(e => e.IdТипаМеста).HasName("типымест_pkey");

            entity.ToTable("типы_мест");

            entity.Property(e => e.IdТипаМеста)
                .HasDefaultValueSql("nextval('\"типымест_idТипаМеста_seq\"'::regclass)")
                .HasColumnName("idТипаМеста");
            entity.Property(e => e.НазваниеТипа)
                .HasMaxLength(45)
                .HasColumnName("Название_типа");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
