const PROXY_CONFIG = [
  {
    context: [
      "/register"
    ],
    target: "https://localhost:7065",
    secure: false,
    logLevel: "debug"
  }
]

module.exports = PROXY_CONFIG;
