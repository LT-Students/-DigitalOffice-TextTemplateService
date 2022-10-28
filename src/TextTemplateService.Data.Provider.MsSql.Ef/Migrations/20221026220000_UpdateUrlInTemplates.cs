using System;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef.Migrations;

[Migration("20221026220000_UpdateUrlInTemplates")]
[DbContext(typeof(TextTemplateServiceDbContext))]
public class UpdateUrlInTemplates : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello {[FirstName]} {[LastName]}!'+CHAR(10)
        +'This is an email for resetting the password to your account.'+CHAR(10)
        +'Follow this link: https://dev.digital-office.dso.lanit-tercom.com/auth/reset?userId={[Id]}'+CHAR(10)
        +'In the first 30 minutes from the moment you got this letter you will need to enter this code to reset your password: {[Password]}'+CHAR(10)
        +'If you didn’t do it during this time — send a new request to reset your password.'+CHAR(10)
        +'If you did not leave a request, please ignore this message.'
        WHERE Name = 'Password recovery'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте, {[FirstName]} {[LastName]}!'+CHAR(10)
        +N'Это письмо для смены пароля к учетной записи в системе.'+CHAR(10)
        +N'Перейдите по этой ссылке: https://dev.digital-office.dso.lanit-tercom.com/auth/reset?userId={[Id]}'+CHAR(10)
        +N'Вам будет необходимо в течение 30 минут от момента получения этого письма ввести код для смены пароля: {[Password]}'+CHAR(10)
        +N'Если вы не успели этого сделать, отправьте новую заявку на сброс пароля.'+CHAR(10)
        +N'Если вы не оставляли заявку, проигнорируйте это сообщение.'
        WHERE Name = N'Восстановление пароля'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello {[FirstName]} {[LastName]}!'+CHAR(10)
        +'This is an email for registration.'+CHAR(10)
        +'If you did not leave a request, please ignore this message.'+CHAR(10)
        +'Follow this link: https://dev.digital-office.dso.lanit-tercom.com/auth/signup?userId={[Id]}'+CHAR(10)
        +'Login: You will need to come up with a new login for your profile. You can use it in the future to log in to the system.'+CHAR(10)
        +'You can also use your corporate email address to log after registration.'+CHAR(10)
        +'Password: {[Password]}'
        WHERE Name = 'Greeting'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте, {[FirstName]} {[LastName]}!'+CHAR(10)
        +N'Это письмо для прохождения регистрации.'+CHAR(10)
        +N'Если вы не оставляли заявку, проигнорируйте это сообщение.'+CHAR(10)
        +N'Перейдите по этой ссылке: https://dev.digital-office.dso.lanit-tercom.com/auth/signup?userId={[Id]}'+CHAR(10)
        +N'Логин: Вам будет необходимо придумать и ввести новый логин. Он в будущем понадобится вам для входа.'+CHAR(10)
        +N'После завершения регистрации для входа также можно будет использовать ваш корпоративный e-mail.'+CHAR(10)
        +N'Пароль: {[Password]}'
        WHERE Name = N'Приглашение'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello {[FirstName]} {[LastName]}!'+CHAR(10)
        +'This is an email for confirming adding a new email to your profile.'+CHAR(10)
        +'To confirm an email follow this link: https://dev.digital-office.dso.lanit-tercom.com/users/{[Id]}?secret={[Secret]}&communicationId={[CommunicationId]}'+CHAR(10)
        +'This link will be active for 30 minutes.'+CHAR(10)
        +'If you did not leave a request, please ignore this message.'
        WHERE Name = 'Mail confirmation'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте, {[FirstName]} {[LastName]}!'+CHAR(10)
        +N'Это письмо для подтверждения добавления в профиль новой электронной почты.'+CHAR(10)
        +N'Для подтверждения адреса электронной почты пройдите по этой ссылке: https://dev.digital-office.dso.lanit-tercom.com/users/{[Id]}?secret={[Secret]}&communicationId={[CommunicationId]}'+CHAR(10)
        +N'Ссылка будет активна в течение 30 минут.'+CHAR(10)
        +N'Если вы не оставляли заявку, пожалуйста, проигнорируйте это сообщение.'
      WHERE Name = N'Подтверждение электронной почты'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello {[FirstName]} {[LastName]}!'+CHAR(10)
        +'This is an email to recover your account.'+CHAR(10)
        +'Follow this link: https://dev.digital-office.dso.lanit-tercom.com/auth/reactivate?userId={[Id]}'+CHAR(10)
        +'Password: {[Password]}'
        WHERE Name = 'User recovery'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте, {[FirstName]} {[LastName]}!'+CHAR(10)
        +N'Это письмо для восстановления вашей учетной записи.'+CHAR(10)
        +N'Перейдите по этой ссылке: https://dev.digital-office.dso.lanit-tercom.com/auth/reactivate?userId={[Id]}'+CHAR(10)
        +N'Пароль: {[Password]}'
        WHERE Name = N'Восстановление пользователя'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello!'+CHAR(10)
        +'This email address was specified as the administrator''s email address to receive the SMTP check''s message.'+CHAR(10)
        +'Receiving this message means that the SMTP check was successful.'+CHAR(10)
        +'If you have not submitted a request, please ignore this message.'
        WHERE Name = 'SMTP settings check'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте!'+CHAR(10)
        +N'Ваша электронная почта была указана как электронная почта администратора для проверки настроек SMTP.'+CHAR(10)
        +N'Получение Вами этого письма означает, что проверка настроек SMTP пройдена успешно.'+CHAR(10)
        +N'Если Вы не отправляли запрос, пожалуйста, проигнорируйте это сообщение.'
        WHERE Name = N'Проверка настроек SMTP'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = 'Hello {[FirstName]} {[LastName]}!'+CHAR(10)
        +'Don''t forget to enter your working hours from {[FirstLastMonth]} to {[LastLastMonth]}'
        +' until {[LastCurrentMonth]} on the time tracking page: https://dev.digital-office.dso.lanit-tercom.com/time',
		Name = 'Working hours',
        Subject = 'Working hours'
        WHERE Name = 'Reminder for employees to enter hours'");

    migrationBuilder.Sql(
      @"UPDATE TextsTemplates SET Text = N'Здравствуйте, {[FirstName]} {[LastName]}!'+CHAR(10)
        +N'Не забудьте внести свои рабочие часы с {[FirstLastMonth]} по {[LastLastMonth]}'+
        +N' до {[LastCurrentMonth]} на странице учёта времени: https://dev.digital-office.dso.lanit-tercom.com/time',
        Name = N'Рабочие часы',
        Subject = N'Рабочие часы'
        WHERE Name = N'Напоминание сотрудникам о внесении часов'");
  }
}
