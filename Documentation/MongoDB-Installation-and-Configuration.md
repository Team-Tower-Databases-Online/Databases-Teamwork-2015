# Инсталация и стартиране на MongoDB под Windows 7/8/10

### Инсталиране на MongoDB на Windows x86 & x64
* Сваляне на MongoDB за x86 базирани операционни системи >>[download link](https://www.mongodb.org/dr/fastdl.mongodb.org/win32/mongodb-win32-i386-3.0.6-signed.msi/download)<<.
* Стартиране на инсталацията с администраторски права, ако потребителят, който ползвате не е администратор, иначе просто кликате два пъти върху сваления _mongodb-win32-i386-3.0.6-signed.msi_ file.
* Избирате 'Custom Installation' и след това за инсталационна папка 'C:\'.
> **Забележка:**
> Важно е да изберете именно 'C:\' като инсталационна директория, защото в противен случай рискувате да имате проблеми с конфигурацията на MongoDB.

### Конфигурация на MongoDB
* Създавате папка 'C:\data', която съдържа поддиректориите 'C:\data\db' & 'C:\data\log'.
* Създавате празене файл _mongod_ с разширение _.log_ в папката 'C:\data\log': 'C:\data\log\mongod.log'.
* Създавате конфигурационен файл _mongod.cfg_ в директорията 'C:\mongodb' със следното съдържание:
```
systemLog:
    destination: file
    path: c:\data\log\mongod.log
storage:
    dbPath: c:\data\db
```
* Добавяте път към \bin директорията в системните променливи:
	* Windows logo key + Pause
	* Advanced System Settings
	* Environment Variables...
	* System variables
	* Double click on Path
	* Insert following line: _C:\mongodb\bin;_
	* Click OK
* Отваряте _cmd.exe_ и пишете: _mongod_
* В стандартния случай ще се отвори предупредителен прозорец от Windows Firewall
* Слагате отметка пред _Private Networks..._ и махате тази пред _Public Networks..._
* Ако всичко е минало успешно, трябва последния ред на конзолата ви да е следният: '_current datetime_ I NETWORK  [initandlisten] waiting for connections on port 27017'
* Ако искате да създадете _Windows Service MongoDB_, който да стартирате чрез командата: $ net start MongoDB, изпълнете следната команда на конзолата:
`$ sc.exe create MongoDB binPath= "C:\mongodb\bin\mongod.exe --service --config=\"C:\mongodb\mongod.cfg\"" DisplayName= "MongoDB" start= "auto"`