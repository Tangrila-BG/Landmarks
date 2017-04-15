function enterCode(number) {
    let inputCode = '';
    swal({
        title: 'Въведете код: ',
        text: 'Въведете кода на забележителността:',
        type: 'input',
        showCancelButton: true,
        closeOnConfirm: false,
        animation: 'slide-from-top',
        inputPlaceholder: 'Код'
    },
    
      function (inputValue) {
          if (inputValue === false) return false;

          if (inputValue === '' || inputValue.length < 5) {
              swal.showInputError('Кодът трябва да се състои от поне 5 символа');
              return false;
          }

          $.post(
          "/Landmark/CheckCode", { id: number, code: inputValue }
          ).then(() => {
              swal('Страхотно!', 'Написахте: ' + inputValue, 'success');
              }
          ).fail(() => {
              swal('Грешка!', 'Кодът не е валиден!', 'success');
          })
          
      });
    return inputCode;
}