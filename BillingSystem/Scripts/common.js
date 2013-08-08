function findLoanIndex(loanStr) {
    if (loanStr == '现金') {
        return 1;
    } else if (loanStr == '转账') {
        return 2;
    }
}