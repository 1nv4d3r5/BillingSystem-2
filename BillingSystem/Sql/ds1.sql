SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `borrow`
-- ----------------------------
DROP TABLE IF EXISTS `borrowing` ;
CREATE TABLE `borrowing`(
`Id` INT(10) UNSIGNED NOT NULL auto_increment PRIMARY KEY COMMENT'Id',
`BorrowORLoan` INT(10) UNSIGNED NOT NULL COMMENT'1:借入；2：借出；',
`BorrowORLoanType` INT(10) UNSIGNED NOT NULL COMMENT'借款方式：1，现金；2，转账；',
`BorrowedAccount` VARCHAR(30) NULL COMMENT'借入账户',
`Borrower` VARCHAR(30) NOT NULL COMMENT'借款人(入)',
`Lender` VARCHAR(30) NOT NULL COMMENT'出借人',
`LoanAccount` VARCHAR(30) NULL COMMENT'借出账户',
`Amount` FLOAT(20,3) NOT NULL COMMENT'金额',
`HappenedDate` datetime NOT NULL COMMENT'发生日期',
`ReturnDate` datetime NULL COMMENT'归还日期',
`Content` VARCHAR(150) NULL COMMENT'备注'
)ENGINE=INNODB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of borrow
-- ----------------------------

-- ----------------------------
-- Table structure for `card`
-- ----------------------------
DROP TABLE IF EXISTS `card`;
CREATE TABLE `card` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `BankId` int(10) unsigned NOT NULL COMMENT '银行Id',
  `CardNumber` varchar(30) NOT NULL COMMENT '卡号',
  `AccountType` int(10) NOT NULL COMMENT '账户类型：1--储蓄账户，2--信用账户',
  `Amount` float(20,3) DEFAULT NULL COMMENT '账户金额',
  `ExpenditureAmount` float(20,3) DEFAULT NULL COMMENT '支出金额',
  `BorrowAmount` float(20,3) DEFAULT NULL COMMENT '借入金额',
  `LoanAmount` float(20,3) DEFAULT NULL COMMENT '借出金额',
  `IncomeAmount` float(20,3) DEFAULT NULL COMMENT '收入金额',
  `OwnerId` int(10) unsigned NOT NULL COMMENT '卡所有者Id',
  `OwnerCode` varchar(30) NOT NULL COMMENT '卡所有者Code',
  `UserId` int(10) unsigned NOT NULL COMMENT '资产所有者',
  `UserCode` varchar(30) NOT NULL COMMENT '资产所有者Code',
  `BankName` varchar(30) DEFAULT NULL COMMENT '开户银行',
  `OpenDate` datetime NOT NULL COMMENT '开户日期',
  `Content` varchar(150) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of card
-- ----------------------------

-- ----------------------------
-- Table structure for `cashincome`
-- ----------------------------
DROP TABLE IF EXISTS `cashincome`;
CREATE TABLE `cashincome` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `OwnerId` int(10) unsigned NOT NULL COMMENT '资产所有者Id',
  `OwnerName` varchar(30) NOT NULL COMMENT '资产所有者名称',
  `CardId` int(10) unsigned NOT NULL COMMENT '卡id',
  `CardNumber` varchar(30) NOT NULL COMMENT '卡号',
  `BankCardNumber` varchar(60) NOT NULL COMMENT '卡号+银行',
  `IncomeAmount` float(20,3) NOT NULL COMMENT '收入金额',
  `PreMode` int(5) unsigned NOT NULL COMMENT '状态前缀',
  `Mode` int(5) unsigned NOT NULL COMMENT '存款状态（1.活期，2定存三个月，3.定存六个月，4.定存一年，5.定存三年，6.定存五年）',
  `PreRate` int(5) unsigned NOT NULL COMMENT '利率前缀',
  `Rate` int(5) unsigned NOT NULL COMMENT '利率',
  `DepositDate` datetime NOT NULL COMMENT '存入日期',
  `BDate` datetime DEFAULT NULL COMMENT '定存开始日期',
  `EDate` datetime DEFAULT NULL COMMENT '到期日期',
  `AutoSave` int(5) unsigned DEFAULT NULL COMMENT '是否自动转存',
  `DepositorId` int(10) unsigned DEFAULT NULL COMMENT '存款人id',
  `DepositorName` varchar(30) NOT NULL COMMENT '存款人',
  `DepositMode` int(5) unsigned NOT NULL COMMENT '存款方式：1、发工资、转账、汇款、现金',
  `Status` int(5) unsigned DEFAULT NULL COMMENT '状态（1.到期，2.未到期，自动转存未到期）',
  `IncomeType` int(5) unsigned NOT NULL COMMENT '收入类型（1.工资，2.奖金，3.股票）',
  `TAmount` float(20,3) DEFAULT NULL COMMENT '到期总金额',
  `Content` varchar(150) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cashincome
-- ----------------------------

-- ----------------------------
-- Table structure for `expenses`
-- ----------------------------
DROP TABLE IF EXISTS `expenses`;
CREATE TABLE `expenses` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `OwnerId` int(10) unsigned NOT NULL COMMENT '资产所有者Id',
  `OwnerName` varchar(30) NOT NULL COMMENT '资产所有者',
  `CardId` int(10) unsigned NOT NULL COMMENT '卡Id',
  `CardNumber` varchar(30) NOT NULL COMMENT '卡号',
  `BankCardNumber` varchar(60) NOT NULL COMMENT '卡号+银行',
  `SpendType` int(5) NOT NULL COMMENT '消费类型',
  `HowToUse` varchar(100) DEFAULT NULL COMMENT '用途',
  `Price` float(20,3) DEFAULT NULL COMMENT '单价',
  `Number` int(10) unsigned DEFAULT NULL COMMENT '数量',
  `Amount` float(20,3) NOT NULL COMMENT '消费金额',
  `SpendDate` datetime NOT NULL COMMENT '消费日期',
  `SpendMode` int(5) unsigned NOT NULL COMMENT '消费方式：1.现金;2.刷卡',
  `ConsumerId` int(10) unsigned NOT NULL COMMENT '消费者Id',
  `ConsumerName` varchar(30) NOT NULL COMMENT '消费者',
  `Content` varchar(150) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of expenses
-- ----------------------------

---- ----------------------------
---- Table structure for `loan`
---- ----------------------------
--DROP TABLE IF EXISTS `loan`;
--CREATE TABLE `loan` (
--  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id',
--  `LoanType` int(10) unsigned NOT NULL COMMENT '出借方式',
--  `Lender` varchar(30) NOT NULL COMMENT '出借人',
--  `LoanAccount` varchar(30) DEFAULT NULL COMMENT '出借账户',
--  `Borrower` varchar(30) NOT NULL COMMENT '借款人',
--  `BorrowAccount` varchar(30) DEFAULT NULL COMMENT '借款账户',
--  `LoanAmount` float(20,3) NOT NULL COMMENT '出借金额',
--  `LoanDate` datetime NOT NULL COMMENT '出借日期',
--  `ReturnDate` datetime DEFAULT NULL COMMENT '归还日期',
--  `Content` varchar(150) DEFAULT NULL COMMENT '备注',
--  PRIMARY KEY (`Id`)
--) ENGINE=InnoDB DEFAULT CHARSET=utf8;

---- ----------------------------
---- Records of loan
---- ----------------------------

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `Code` varchar(10) NOT NULL COMMENT 'Code',
  `Name` varchar(30) NOT NULL COMMENT '名称',
  `Password` varchar(100) NOT NULL COMMENT '密码',
  `EMail` varchar(30) DEFAULT NULL COMMENT '邮箱',
  `Role` int(10) unsigned NOT NULL COMMENT '权限',
  `Content` varchar(150) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
