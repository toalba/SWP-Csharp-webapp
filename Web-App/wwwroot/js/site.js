// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(() => {
    'use strict'

    // Set Bootstrap Theme to the preferred color scheme
    const setPreferredTheme = () => {
        if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
            document.documentElement.setAttribute('data-bs-theme', 'dark')
        } else {
            document.documentElement.setAttribute('data-bs-theme', 'light')
        }
    }

    window.addEventListener('DOMContentLoaded', () => {
        setPreferredTheme()
    })
})()