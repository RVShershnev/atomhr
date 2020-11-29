# Atom.HR.Dss

Требования: Visual Studio 2019 Preview .NET 5.0
Visual Studio Code (Python 3.7.6)


Запускается проект Atom.HR.WebAssistant -- веб приложение.
В репозитории хранится сертификат. 
Для полного функционирования приложения, необходимо подключиться к облачной базе данных RavenDB.
В базе данных настроен вайтлист для айпи, чтоб получить доступ, пришлите мне свой айпи telegram @rvsher.

Безсерверные функции могут быть разврнуты в AZURE облаке
Azure-functions:
Скрапинг hh.ru

Ответ: список резюме

Классификация специализации по скиллам:
https://skilltospecialization.azurewebsites.net/api/HttpTrigger1/?area_id=1&skills=%22%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%BE%D1%81%D0%BF%D0%BE%D1%81%D0%BE%D0%B1%D0%BD%D0%BE%D1%81%D1%82%D1%8C%20%D0%9E%D1%82%D0%B2%D0%B5%D1%82%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D1%8C%20%D0%9A%D0%BE%D0%BC%D0%BC%D1%83%D0%BD%D0%B8%D0%BA%D0%B0%D0%B1%D0%B5%D0%BB%D1%8C%D0%BD%D0%BE%D1%81%D1%82%D1%8C%20%D0%A1%D1%82%D1%80%D0%B5%D1%81%D1%81%D0%BE%D1%83%D1%81%D1%82%D0%BE%D0%B9%D1%87%D0%B8%D0%B2%D0%BE%D1%81%D1%82%D1%8C%20%D0%9F%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%20%D0%9F%D0%9A%20MS%20PowerPoint%20MS%20Access%20MS%20Word%20MS%20Excel%20MATLAB%20%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D0%B2%20%D0%BA%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D0%B5%22
Ответ: название специализации.

Тестовое задание для кандидата:
http://localhost:7071/api/HttpTrigger1?ans1=0&ans2=1&ans3=2&ans4=0&ans5=2&ans6=1&ans7=2&ans8=0&ans9=0&ans10=1

Ответ: количество баллов.


Прогнозирование зарплаты от специализации:
https://zarplata.azurewebsites.net/api/HttpTrigger1?spec_param=%22%D0%A1%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%BD%D1%8B%D0%B9%20%D0%B0%D0%B4%D0%BC%D0%B8%D0%BD%D0%B8%D1%81%D1%82%D1%80%D0%B0%D1%82%D0%BE%D1%80%22
http://localhost:7071/api/HttpTrigger1?spec_param="Системный администратор"

Ответ: min, avg, max, mediana.
