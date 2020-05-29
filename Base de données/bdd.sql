-- Table structure for table `users`
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
);



-- Dumping data for table `users`
INSERT INTO `users` (`username`, `password`) VALUES
( 'unity', sha1('unity1') ),
( 'test', sha1('test') );
COMMIT;

