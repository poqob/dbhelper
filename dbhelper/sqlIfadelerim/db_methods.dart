//queries to database according to index numbers that db has serial.
import 'dart:async';
import 'package:postgres/postgres.dart';

class DBActions with UserData {
  PostgreSQLConnection? connection;
  DBActions() {
    connection = PostgreSQLConnection("localhost", 5432, "postgres",
        username: "dart", password: "123456");
    connection!.open();
  }
  Future<void> openConn() async {
    try {
      await connection!.open();
    } catch (e) {}
  }

  Future<void> closeConn() async {
    Future.delayed(
      const Duration(seconds: 3),
      () => connection!.close(),
    );
  }

//User auth
  Future<bool> auth(String username, String password) async {
    var results;
    var userid;
    results = await connection!.query('''
  SELECT users.auth('$username','$password');
''');
    results[0][0] == true
        ? wellcome(username, password, connection!)
        : print(results[0][0]);
    await printerrr();
    await closeConn();
    return results[0][0];
  }

  Future<void> close() async {
    await goodbye();
  }
}

mixin UserData {
  PostgreSQLConnection? conn_;
  String? username_;
  String? password_;
  DateTime? lastLoggedIn;
  DateTime? dt;
  dynamic totalElapsedTime;
  dynamic userid;
  bool? online_status;
  final stopwatch = Stopwatch();

  Future<void> wellcome(
      String username, String password, PostgreSQLConnection conn) async {
    username_ = username;
    password_ = password;
    online_status = true;
    conn_ = conn;
    lastLoggedIn = DateTime.now();
    stopwatch.start();

    //find out
    String sq =
        "select user_id from users.users where user_name='$username' and user_password='$password';";
    userid = await conn.query(sq);

    await set_online_status(conn, online_status!);
  }

  Future<void> set_online_status(
      PostgreSQLConnection conn, bool boolean) async {
    String sq =
        "update users.user_data set online_status='$boolean' where user_id='${userid[0][0]}';";
    await conn.query(sq);
  }

  Future<void> printerrr() async {
    print(
        "username=$username_ password=$password_ user_id=${userid[0][0]} online status=${online_status}");
  }

  Future<void> goodbye() async {
    stopwatch.stop();
    dt = DateTime.now();
    String sq =
        "select total_minute_consuming from users.user_data where user_id='${userid[0][0]}';";
    totalElapsedTime = await conn_?.query(sq);
    int result = totalElapsedTime[0][0] + stopwatch.elapsed.inMinutes;

    //setting total consumed time
    sq =
        "update users.user_data set total_minute_consuming='$result' where user_id= '${userid[0][0]}' ;";
    await conn_?.query(sq);

    //setting last logout date
    sq =
        "update users.user_data set last_logout='${dt!.day}/${dt!.month}/${dt!.year} where user_id='${userid[0][0]}'";
    await conn_?.query(sq);

    //setting online status 0
    await set_online_status(conn_!, false);

    conn_?.close();
    conn_!.isClosed ? print("db closed") : print("db still open");
  }
}
