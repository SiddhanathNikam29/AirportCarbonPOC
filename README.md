\# ✈️ Airport Carbon Hotspot Tool — POC



> A browser-based proof of concept that identifies \*\*one\*\* avoidable operational emission hotspot at an airport and simulates the impact of \*\*one\*\* intervention.



!\[Status](https://img.shields.io/badge/status-POC-blue)

!\[.NET](https://img.shields.io/badge/.NET-9.0-purple)

!\[React](https://img.shields.io/badge/React-18-61dafb)

!\[License](https://img.shields.io/badge/license-MIT-green)



\---



\## 📖 Table of Contents



\- \[Overview](#-overview)

\- \[Problem Statement](#-problem-statement)

\- \[What This POC Is / Is Not](#-what-this-poc-is--is-not)

\- \[Architecture](#-architecture)

\- \[Tech Stack](#-tech-stack)

\- \[Project Structure](#-project-structure)

\- \[Getting Started](#-getting-started)

&#x20; - \[Prerequisites](#prerequisites)

&#x20; - \[Backend Setup](#backend-setup)

&#x20; - \[Frontend Setup](#frontend-setup)

\- \[API Reference](#-api-reference)

\- \[How It Works](#-how-it-works)

\- \[Screenshots](#-screenshots)

\- \[Testing](#-testing)

\- \[Constraints \& Design Decisions](#-constraints--design-decisions)

\- \[Limitations](#-limitations)

\- \[Future Extensions](#-future-extensions)

\- \[Troubleshooting](#-troubleshooting)

\- \[License](#-license)



\---



\## 🎯 Overview



Airports today produce detailed \*\*sustainability reports after the fact\*\*, but rarely provide \*\*forward-looking, actionable guidance\*\* on what to do next. This POC bridges that gap.



\*\*In one sentence:\*\* Given synthetic airport operational data, the tool identifies the single biggest avoidable emission hotspot and simulates the before/after impact of one operational intervention.



\*\*Example output:\*\*

\- 🔴 \*\*Hotspot Identified:\*\* Excess Gate APU Usage (820 kg CO₂)

\- 💡 \*\*Recommendation:\*\* Connect aircraft to Fixed Electrical Ground Power (FEGP)

\- 📊 \*\*Simulated Savings:\*\* −410 kg CO₂ (43.8%)



\---



\## ❓ Problem Statement



> \*"Airports have sustainability reports that explain consumption after the fact, but provide limited guidance on the next operational action."\*



This POC turns post-hoc reporting into \*\*actionable, forward-looking simulation\*\* — while respecting hard boundaries around aviation safety and scope.



\---



\## ✅ What This POC Is / Is Not



| ✅ This POC IS | ❌ This POC IS NOT |

|---|---|

| A single-hotspot detection tool | A full sustainability platform |

| A one-recommendation engine | A multi-tenant analytics suite |

| A synthetic-data simulator | A live operational control system |

| A demonstration of concept | A production deployment |



\---



\## 🏗️ Architecture



