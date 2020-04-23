package com.epam.university.web.form.mapper;


@FunctionalInterface
public interface FormEntityMapper<T, E> {
    T map(E form);
}
