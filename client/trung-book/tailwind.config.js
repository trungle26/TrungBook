/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
        'bookstore': "url('/src/assets/background.png')",
        'navbar': "url('/src/assets/navbar.jpg')",
      }
    },
  },
  plugins: [],
}

