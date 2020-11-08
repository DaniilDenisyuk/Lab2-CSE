# Lab2-SIC

тести до бібліотеки BinaryFlag
притримуючись таких методів Black Box Testing: аналіз граничних
значень та класи еквівалентності. 
Бібліотека BinaryFlag налічує
такі методи:
• SetFlag(ulong position); - встановлює значення флагу у заданій
позиції (position) на true.
• ResetFlag(ulong position); - встановлює значення флагу у заданій
позиції (position) на false.
• GetFlag(); - вертає значення множинного двійкового флагу. Якщо
усі позиції флагу мають значення true - вератє true, в усіх інших
випадках - вертає false.
• Despose(); - утилізує об’єкт.

Техніка аналізу граничних значень була використана у тестах максимальної
та мінімальної довжини флагу. Я дійшов висновку, що тут необґрунтоване
використання типу ulong в параметрі довжини, оскільки граничне значення 
на порядки менше, ніж може в собі вмістити даний тип.
Техніка еквівалентного розбиття була використана у тестах для методів 
GetFlag(), SetFLag(), ResetFlag().
Нажаль, я не знайшов, яким чином можна перевірити чи дійсно об'єкт
утилізується методом Dispose(), не залазячи в сам код бібліотеки.