package com.epam.university.web.form.validator;

public interface FormValidator<T> {
     boolean validate(T form);
}
